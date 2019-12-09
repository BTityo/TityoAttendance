using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TityoAttendance.TityoAttendance.TityoProject.Dto
{
    [AutoMapTo(typeof(Project))]
    public class CreateProjectDto
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
    }
}
