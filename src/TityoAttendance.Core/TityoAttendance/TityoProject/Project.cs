using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TityoAttendance.TityoAttendance.TityoAttendance;
using TityoAttendance.TityoAttendance.TityoCompany;
using TityoAttendance.TityoAttendance.TityoSalary;

namespace TityoAttendance.TityoAttendance.TityoProject
{
    [Table("Project", Schema = "Project")]
    public class Project : Entity<int>
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
        public Company Company { get; set; }

        public ICollection<Salary> Salaries { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
