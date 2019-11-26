using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TityoAttendance.Configuration.Dto;

namespace TityoAttendance.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TityoAttendanceAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
