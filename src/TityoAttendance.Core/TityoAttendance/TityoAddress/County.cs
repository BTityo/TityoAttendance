using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TityoAttendance.TityoAttendance.TityoAddress
{
    [Table("County", Schema = "Address")]
    public class County : Entity<int>
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountyCode { get; set; }


        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
