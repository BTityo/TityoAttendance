using System.Threading.Tasks;
using TityoAttendance.Configuration.Dto;

namespace TityoAttendance.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
