using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TityoAttendance.TityoAttendance.TityoAddress.Dto
{
    [AutoMapFrom(typeof(City))]
    public class CityDto : EntityDto<int>
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
    }
}
