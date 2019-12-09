using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TityoAttendance.TityoAttendance.TityoAddress.Dto
{
    [AutoMapFrom(typeof(County))]
    public class CountyDto : EntityDto<int>
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountyCode { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountryCode { get; set; }
    }
}
