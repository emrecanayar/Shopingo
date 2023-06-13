﻿using Core.Application.Base.Commands.Create;
using Core.Application.Base.Commands.Delete;
using Core.Application.Base.Commands.Update;
using Core.Application.Base.Queries.GetById;
using Core.Application.Base.Queries.GetList;
using Core.Application.Base.Queries.GetListByDynamic;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using webAPI.Application.Features.Categories.Dtos;
using webAPI.Application.Features.Categories.Models;
using webAPI.Application.Features.ContactInfos.Dtos;
using webAPI.Application.Features.ContactInfos.Models;
using webAPI.Application.Features.Products.Dtos;
using webAPI.Application.Features.Products.Models;
using webAPI.Application.Features.Sizes.Dtos;
using webAPI.Application.Features.Sizes.Models;
using webAPI.Application.Features.SubCategories.Dtos;
using webAPI.Application.Features.SubCategories.Models;

namespace webAPI.Application
{
    public static class BaseServiceRegistration
    {
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            #region Category
            services.AddScoped<IRequestHandler<GetListQuery<Category, CategoryListModel>, CustomResponseDto<CategoryListModel>>, GetListQuery<Category, CategoryListModel>.GetListQueryHandler>();
            services.AddScoped<IRequestHandler<GetByIdQuery<Category, CategoryDto>, CustomResponseDto<CategoryDto>>, GetByIdQuery<Category, CategoryDto>.GetByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetListByDynamicQuery<Category, CategoryListModel>, CustomResponseDto<CategoryListModel>>, GetListByDynamicQuery<Category, CategoryListModel>.GetListByDynamicQueryHandler>();
            services.AddScoped<IRequestHandler<CreateCommand<Category, CategoryCreateDto>, CustomResponseDto<CategoryCreateDto>>, CreateCommand<Category, CategoryCreateDto>.CreateCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCommand<Category, CategoryUpdateDto>, CustomResponseDto<CategoryUpdateDto>>, UpdateCommand<Category, CategoryUpdateDto>.UpdateCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCommand<Category, CategoryDeleteDto>, CustomResponseDto<bool>>, DeleteCommand<Category, CategoryDeleteDto>.DeleteCommandHandler>();
            #endregion

            #region SubCategory
            services.AddScoped<IRequestHandler<GetListQuery<SubCategory, SubCategoryListModel>, CustomResponseDto<SubCategoryListModel>>, GetListQuery<SubCategory, SubCategoryListModel>.GetListQueryHandler>();
            services.AddScoped<IRequestHandler<GetByIdQuery<SubCategory, SubCategoryDto>, CustomResponseDto<SubCategoryDto>>, GetByIdQuery<SubCategory, SubCategoryDto>.GetByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetListByDynamicQuery<SubCategory, SubCategoryListModel>, CustomResponseDto<SubCategoryListModel>>, GetListByDynamicQuery<SubCategory, SubCategoryListModel>.GetListByDynamicQueryHandler>();
            services.AddScoped<IRequestHandler<CreateCommand<SubCategory, SubCategoryCreateDto>, CustomResponseDto<SubCategoryCreateDto>>, CreateCommand<SubCategory, SubCategoryCreateDto>.CreateCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCommand<SubCategory, SubCategoryUpdateDto>, CustomResponseDto<SubCategoryUpdateDto>>, UpdateCommand<SubCategory, SubCategoryUpdateDto>.UpdateCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCommand<SubCategory, SubCategoryDeleteDto>, CustomResponseDto<bool>>, DeleteCommand<SubCategory, SubCategoryDeleteDto>.DeleteCommandHandler>();
            #endregion

            #region ContactInfo
            services.AddScoped<IRequestHandler<GetListQuery<ContactInfo, ContactInfoListModel>, CustomResponseDto<ContactInfoListModel>>, GetListQuery<ContactInfo, ContactInfoListModel>.GetListQueryHandler>();
            services.AddScoped<IRequestHandler<GetByIdQuery<ContactInfo, ContactInfoDto>, CustomResponseDto<ContactInfoDto>>, GetByIdQuery<ContactInfo, ContactInfoDto>.GetByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetListByDynamicQuery<ContactInfo, ContactInfoListModel>, CustomResponseDto<ContactInfoListModel>>, GetListByDynamicQuery<ContactInfo, ContactInfoListModel>.GetListByDynamicQueryHandler>();
            services.AddScoped<IRequestHandler<CreateCommand<ContactInfo, ContactInfoCreateDto>, CustomResponseDto<ContactInfoCreateDto>>, CreateCommand<ContactInfo, ContactInfoCreateDto>.CreateCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCommand<ContactInfo, ContactInfoUpdateDto>, CustomResponseDto<ContactInfoUpdateDto>>, UpdateCommand<ContactInfo, ContactInfoUpdateDto>.UpdateCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCommand<ContactInfo, ContactInfoDeleteDto>, CustomResponseDto<bool>>, DeleteCommand<ContactInfo, ContactInfoDeleteDto>.DeleteCommandHandler>();
            #endregion

            #region Size
            services.AddScoped<IRequestHandler<GetListQuery<Size, SizeListModel>, CustomResponseDto<SizeListModel>>, GetListQuery<Size, SizeListModel>.GetListQueryHandler>();
            services.AddScoped<IRequestHandler<GetByIdQuery<Size, SizeDto>, CustomResponseDto<SizeDto>>, GetByIdQuery<Size, SizeDto>.GetByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetListByDynamicQuery<Size, SizeListModel>, CustomResponseDto<SizeListModel>>, GetListByDynamicQuery<Size, SizeListModel>.GetListByDynamicQueryHandler>();
            services.AddScoped<IRequestHandler<CreateCommand<Size, SizeCreateDto>, CustomResponseDto<SizeCreateDto>>, CreateCommand<Size, SizeCreateDto>.CreateCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCommand<Size, SizeUpdateDto>, CustomResponseDto<SizeUpdateDto>>, UpdateCommand<Size, SizeUpdateDto>.UpdateCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCommand<Size, SizeDeleteDto>, CustomResponseDto<bool>>, DeleteCommand<Size, SizeDeleteDto>.DeleteCommandHandler>();
            #endregion

            #region Product
            services.AddScoped<IRequestHandler<GetListQuery<Product, ProductListModel>, CustomResponseDto<ProductListModel>>, GetListQuery<Product, ProductListModel>.GetListQueryHandler>();
            services.AddScoped<IRequestHandler<GetByIdQuery<Product, ProductDto>, CustomResponseDto<ProductDto>>, GetByIdQuery<Product, ProductDto>.GetByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetListByDynamicQuery<Product, ProductListModel>, CustomResponseDto<ProductListModel>>, GetListByDynamicQuery<Product, ProductListModel>.GetListByDynamicQueryHandler>();
            #endregion
            return services;

        }
    }
}
