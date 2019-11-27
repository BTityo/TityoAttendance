using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TityoAttendance.TityoAttendance.TityoAddress;

namespace TityoAttendance.TityoAttendance.TityoCompany
{
    [Table("Company", Schema = "Company")]
    public class Company : Entity<int>
    {
        [Required]
        public string Name { get; set; }


        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
