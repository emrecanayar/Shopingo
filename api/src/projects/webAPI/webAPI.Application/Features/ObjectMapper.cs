using Application.Features.SystemParameters.Profiles;
using Application.Features.Users.Profiles;
using AutoMapper;
using webAPI.Application.Features.AboutUsPage.Profiles;
using webAPI.Application.Features.Auths.Profiles;
using webAPI.Application.Features.Categories.Profiles;
using webAPI.Application.Features.CompanyAddresses.Profiles;
using webAPI.Application.Features.ContactInfos.Profiles;
using webAPI.Application.Features.ContactUsForms.Profiles;
using webAPI.Application.Features.Countries.Profiles;
using webAPI.Application.Features.OperationClaims.Profiles;
using webAPI.Application.Features.ProductColors.Profiles;
using webAPI.Application.Features.ProductDeliveries.Profiles;
using webAPI.Application.Features.Products.Profiles;
using webAPI.Application.Features.ProductSizes.Profiles;
using webAPI.Application.Features.ProductUploadedFiles.Profiles;
using webAPI.Application.Features.Sizes.Profiles;
using webAPI.Application.Features.SubCategories.Profiles;
using webAPI.Application.Features.UserOperationClaims.Profiles;

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
                configuration.AddProfile<ProductColorMappingProfiles>();
                configuration.AddProfile<ProductDeliveryMappingProfiles>();
                configuration.AddProfile<ProductSizeMappingProfiles>();
                configuration.AddProfile<ProductUploadedFileMappingProfiles>();
                configuration.AddProfile<ProductMappingProfiles>();
                configuration.AddProfile<ContactUsFormMappingProfiles>();
                configuration.AddProfile<CompanyAddressMappigProfiles>();
                configuration.AddProfile<AboutUsMappingProfiles>();
                configuration.AddProfile<OperationClaimMappingProfiles>();
                configuration.AddProfile<UserOperationClaimMappingProfiles>();
                configuration.AddProfile<CountryMappingProfiles>();

            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}