using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TityoAttendance.TityoAttendance.TityoAddress
{
    [Table("NatureOfPublicPlace", Schema = "Address")]
    public class NatureOfPublicPlace : Entity<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
