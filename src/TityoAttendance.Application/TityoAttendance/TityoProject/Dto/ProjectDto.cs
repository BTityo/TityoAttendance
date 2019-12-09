using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using TityoAttendance.TityoAttendance.TityoCompany.Dto;

namespace TityoAttendance.TityoAttendance.TityoProject.Dto
{
    [AutoMapFrom(typeof(Project))]
    public class ProjectDto : EntityDto<int>
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [MinLength(3), MaxLength(8)]
        public string Color { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
