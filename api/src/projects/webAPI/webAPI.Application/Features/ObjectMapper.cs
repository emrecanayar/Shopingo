using Application.Features.SystemParameters.Profiles;
using Application.Features.Users.Profiles;
using AutoMapper;
using webAPI.Application.Features.Auths.Profiles;
using webAPI.Application.Features.Categories.Profiles;
using webAPI.Application.Features.ContactInfos.Profiles;
using webAPI.Application.Features.Sizes.Profiles;
using webAPI.Application.Features.SubCategories.Profiles;

namespace webAPI.Application.Features
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<UserMappingProfiles>();
                configuration.AddProfile<AuthMappingProfiles>();
                configuration.AddProfile<SystemParameterMappingProfiles>();
                configuration.AddProfile<CategoryMappingProfiles>();
                configuration.AddProfile<SubCategoryMappingProfiles>();
                configuration.AddProfile<ContactInfoMappingProfiles>();
                configuration.AddProfile<SizeMappingProfiles>();

            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}