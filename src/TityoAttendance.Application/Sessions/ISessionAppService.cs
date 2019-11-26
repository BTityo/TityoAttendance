using System.Threading.Tasks;
using Abp.Application.Services;
using TityoAttendance.Sessions.Dto;

namespace TityoAttendance.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
