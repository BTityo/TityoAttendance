using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using TityoAttendance.TityoAttendance.TityoAddress.Dto;

namespace TityoAttendance.TityoAttendance.TityoCompany.Dto
{
    [AutoMapFrom(typeof(Company))]
    public class CompanyDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(9), MinLength(9)]
        [Phone]
        public string MobilePhone { get; set; }


        [Required]
        public int AddressId { get; set; }
        public AddressDto Address { get; set; }
    }
}
