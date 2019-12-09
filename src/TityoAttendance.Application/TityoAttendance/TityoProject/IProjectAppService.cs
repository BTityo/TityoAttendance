using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using TityoAttendance.TityoAttendance.TityoProject.Dto;

namespace TityoAttendance.TityoAttendance.TityoProject
{
    public interface IProjectAppService : IAsyncCrudAppService<ProjectDto, int, PagedTityoResultRequestDto, CreateProjectDto, ProjectDto>
    {
        Task<ListResultDto<ProjectDto>> GetAllByCompanyAsync(PagedTityoResultRequestDto inputDto, int companyId);
        Task<bool> CheckColorIsExistsAsync(string color);
    }
}
