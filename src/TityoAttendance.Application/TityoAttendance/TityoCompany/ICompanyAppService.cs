using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using TityoAttendance.TityoAttendance.TityoCompany.Dto;

namespace TityoAttendance.TityoAttendance.TityoCompany
{
    public interface ICompanyAppService : IAsyncCrudAppService<CompanyDto, int, PagedTityoResultRequestDto, CreateCompanyDto, CompanyDto>
    {
        Task<List<CompanyDto>> GetAllByUserAsync();
        Task<ListResultDto<CompanyDto>> GetAllWithAddressAsync(PagedTityoResultRequestDto inputDto);
        Task<CompanyDto> GetCompanyDtoAsync(int id);
    }
}
