using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TityoAttendance.TityoAttendance.TityoAddress
{
    [Table("Country", Schema = "Address")]
    public class Country : Entity<int>
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountryCode { get; set; }


        public ICollection<Address> Addresses { get; set; }
    }
}
