using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TityoAttendance.TityoAttendance.TityoAddress.Dto
{
    [AutoMapFrom(typeof(Address))]
    public class AddressDto : EntityDto<int>
    {
        [Required]
        public string Street { get; set; }

        [Required]
        [MaxLength(8)]
        public string HouseNumber { get; set; }


        [Required]
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }

        [Required]
        public int CountyId { get; set; }
        public CountyDto County { get; set; }

        [Required]
        public int CityId { get; set; }
        public CityDto City { get; set; }

        [Required]
        public int NatureOfPublicPlaceId { get; set; }
        public NatureOfPublicPlaceDto NatureOfPublicPlace { get; set; }
    }
}
