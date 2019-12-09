using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TityoAttendance.TityoAttendance.TityoAddress
{
    [Table("City", Schema = "Address")]
    public class City : Entity<int>
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [Range(1011, 9999)]
        public short ZipCode { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountyCode { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
