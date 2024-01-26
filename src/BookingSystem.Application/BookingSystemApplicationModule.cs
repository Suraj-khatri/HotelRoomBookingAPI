using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookingSystem.Authorization;

namespace BookingSystem
{
    [DependsOn(
        typeof(BookingSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BookingSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BookingSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BookingSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
