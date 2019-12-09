using Abp.Application.Services.Dto;

namespace TityoAttendance.TityoAttendance
{
    public class PagedTityoResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
