using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TityoAttendance.Roles.Dto;
using TityoAttendance.Users.Dto;

namespace TityoAttendance.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
