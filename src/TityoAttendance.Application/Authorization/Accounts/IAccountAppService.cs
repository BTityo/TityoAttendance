using System.Threading.Tasks;
using Abp.Application.Services;
using TityoAttendance.Authorization.Accounts.Dto;

namespace TityoAttendance.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
