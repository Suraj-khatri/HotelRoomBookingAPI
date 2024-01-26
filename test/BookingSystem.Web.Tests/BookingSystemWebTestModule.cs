using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookingSystem.EntityFrameworkCore;
using BookingSystem.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BookingSystem.Web.Tests
{
    [DependsOn(
        typeof(BookingSystemWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BookingSystemWebTestModule : AbpModule
    {
        public BookingSystemWebTestModule(BookingSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BookingSystemWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BookingSystemWebMvcModule).Assembly);
        }
    }
}