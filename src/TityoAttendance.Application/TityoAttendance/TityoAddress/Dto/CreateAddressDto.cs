using Abp.AutoMapper;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace TityoAttendance.TityoAttendance.TityoAddress.Dto
{
    [AutoMapTo(typeof(Address))]
    public class CreateAddressDto
    {
        [Required]
        public string Street { get; set; }

        [Required]
        [MaxLength(8)]
        public string HouseNumber { get; set; }


        [Required]
        public int CountryId { get; set; }

        [Required]
        public int CountyId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int NatureOfPublicPlaceId { get; set; }
    }
}
