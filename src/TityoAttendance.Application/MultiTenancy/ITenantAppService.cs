using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TityoAttendance.MultiTenancy.Dto;

namespace TityoAttendance.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

