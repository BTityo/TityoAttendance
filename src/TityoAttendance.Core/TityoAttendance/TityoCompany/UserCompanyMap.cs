using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TityoAttendance.Authorization.Users;
using TityoAttendance.TityoAttendance.TityoSalary;

namespace TityoAttendance.TityoAttendance.TityoCompany
{
    [Table("UserCompanyMap", Schema = "Company")]
    public class UserCompanyMap : Entity<int>
    {
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Salary> Salaries { get; set; }
    }
}
