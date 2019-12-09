using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TityoAttendance.TityoAttendance.TityoAddress.Dto
{
    [AutoMapFrom(typeof(NatureOfPublicPlace))]
    public class NatureOfPublicPlaceDto : EntityDto<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
