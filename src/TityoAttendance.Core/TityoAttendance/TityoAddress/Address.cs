using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TityoAttendance.TityoAttendance.TityoCompany;

namespace TityoAttendance.TityoAttendance.TityoAddress
{
    [Table("Address", Schema = "Address")]
    public class Address : Entity<int>
    {
        [Required]
        public string Street { get; set; }

        [Required]
        [MaxLength(8)]
        public string HouseNumber { get; set; }


        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Required]
        public int CountyId { get; set; }
        public County County { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required]
        public int NatureOfPublicPlaceId { get; set; }
        public NatureOfPublicPlace NatureOfPublicPlace { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
