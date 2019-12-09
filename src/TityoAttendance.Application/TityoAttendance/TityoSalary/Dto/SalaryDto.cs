using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TityoAttendance.TityoAttendance.TityoProject.Dto;

namespace TityoAttendance.TityoAttendance.TityoSalary.Dto
{
    [AutoMapFrom(typeof(Salary))]
    public class SalaryDto : EntityDto<int>
    {
        [Required]
        [DefaultValue(0)]
        public int AllWorkedHours { get; set; }

        [Required]
        [DefaultValue(0)]
        public int AllPaidHours { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Income { get; set; }

        // Salary
        [Required]
        [DefaultValue(0)]
        public int HourlyWage { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public ProjectDto Project { get; set; }
    }
}
