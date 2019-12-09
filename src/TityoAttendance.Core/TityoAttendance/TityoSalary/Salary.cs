using Abp.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TityoAttendance.TityoAttendance.TityoCompany;
using TityoAttendance.TityoAttendance.TityoProject;

namespace TityoAttendance.TityoAttendance.TityoSalary
{
    [Table("Salary", Schema = "Salary")]
    public class Salary : Entity<int>
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
        public Project Project { get; set; }
    }
}
