using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TityoAttendance.Controllers
{
    public abstract class TityoAttendanceControllerBase: AbpController
    {
        protected TityoAttendanceControllerBase()
        {
            LocalizationSourceName = TityoAttendanceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
