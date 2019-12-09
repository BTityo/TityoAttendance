using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TityoAttendance.TityoAttendance.TityoAddress;
using TityoAttendance.TityoAttendance.TityoProject;

namespace TityoAttendance.TityoAttendance.TityoCompany
{
    [Table("Company", Schema = "Company")]
    public class Company : Entity<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(9), MinLength(9)]
        [Phone]
        public string MobilePhone { get; set; }


        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
