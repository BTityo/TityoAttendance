using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TityoAttendance.Configuration;

namespace TityoAttendance.Web.Host.Startup
{
    [DependsOn(
       typeof(TityoAttendanceWebCoreModule))]
    public class TityoAttendanceWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TityoAttendanceWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TityoAttendanceWebHostModule).GetAssembly());
        }
    }
}
