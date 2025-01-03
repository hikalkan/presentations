﻿using System;
using Acme.BookStore.Books;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Entities.Caching;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Acme.BookStore;

[DependsOn(
    typeof(BookStoreDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(BookStoreApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class BookStoreApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddEntityCache<Book, BookDto, Guid>();
        
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BookStoreApplicationModule>();
        });
    }
}
