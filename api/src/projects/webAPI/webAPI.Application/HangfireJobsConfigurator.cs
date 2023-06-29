using Core.BackgroundJob.Services;
using Microsoft.Extensions.DependencyInjection;
using webAPI.Application.Jobs.RecurringJobs;

namespace webAPI.Application
{
    public class HangfireJobsConfigurator
    {
        private readonly IServiceProvider _serviceProvider;

        public HangfireJobsConfigurator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Configure()
        {
            var jobService = _serviceProvider.GetRequiredService<IJobService>();
            jobService.Recurring<CampaignEmailJob>(x => x.Execute(), "0 0 * * *");

        }
    }
}
