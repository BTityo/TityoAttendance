using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TityoAttendance.Authorization;

namespace TityoAttendance
{
    [DependsOn(
        typeof(TityoAttendanceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TityoAttendanceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TityoAttendanceAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TityoAttendanceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
