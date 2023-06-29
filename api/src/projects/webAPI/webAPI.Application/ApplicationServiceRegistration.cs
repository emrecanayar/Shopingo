using Core.Application.Base.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching.DisturbedCache;
using Core.Application.Pipelines.CheckId;
using Core.Application.Pipelines.DbLogging;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Security;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.DbLog;
using Core.CrossCuttingConcerns.Logging.DbLog.Mongo;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.ElasticSearch;
using Core.Helpers.Extensions;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using webAPI.Application.Behaviors;
using webAPI.Application.Services.AuthService;
using webAPI.Application.Services.UserService;

namespace webAPI.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            services.AddScoped<IElasticSearch, ElasticSearchManager>();

            services.AddScopedWithManagers(typeof(IAuthService).Assembly);
            services.AddSingleton<LoggerServiceBase, FileLogger>();
            services.AddSingleton<IMailService, MailKitMailService>();
            services.AddSingleton<IDecryptService, DecryptService>();


            services.Configure<LogDatabaseSettings>(configuration.GetSection(nameof(LogDatabaseSettings)));
            services.AddSingleton<ILogDatabaseSettings>(sp => sp.GetRequiredService<IOptions<LogDatabaseSettings>>().Value);
            services.AddLogging();
            services.AddSingleton<Logging>();
            services.AddSingleton<ILogService, MongoLogService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserAccessor, UserAccessor>();

            services.AddScoped(typeof(BaseBusinessRules<>));

            services.AddSingleton<CustomStringLocalizer>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
                configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
                configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
                //configuration.AddOpenBehavior(typeof(LocalizationBehavior<,>));
                configuration.AddOpenBehavior(typeof(PerformanceBehavior<,>));
                configuration.AddOpenBehavior(typeof(DbLoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(CheckIdBehavior<,>));
                configuration.AddOpenBehavior(typeof(PostProcessingBehavior<,>));
                configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));

            });

            return services;

        }

        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type,
                                                            Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddScoped(item);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }
            return services;
        }

        public static IServiceCollection AddScopedWithManagers(this IServiceCollection services, Assembly assembly)
        {
            var serviceTypes = assembly.GetTypes()
                                       .Where(t => t.IsInterface && t.Name.EndsWith("Service"));

            foreach (var serviceType in serviceTypes)
            {
                var managerTypeName = serviceType.Name.Replace("Service", "Manager").ReplaceFirst("I", "");
                var managerType = assembly.GetTypes().SingleOrDefault(t => t.Name == managerTypeName);

                if (managerType != null)
                {
                    services.AddScoped(serviceType, managerType);
                }
            }

            return services;
        }
    }
}
