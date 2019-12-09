using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TityoAttendance.TityoAttendance.TityoSalary.Dto
{
    [AutoMapTo(typeof(Salary))]
    public class CreateSalaryDto
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
    }
}
