using Abp.Application.Services.Dto;

namespace TityoAttendance.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

