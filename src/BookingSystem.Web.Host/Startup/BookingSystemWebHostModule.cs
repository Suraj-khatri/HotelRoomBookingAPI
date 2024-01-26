using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookingSystem.Configuration;

namespace BookingSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(BookingSystemWebCoreModule))]
    public class BookingSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BookingSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BookingSystemWebHostModule).GetAssembly());
        }
    }
}
