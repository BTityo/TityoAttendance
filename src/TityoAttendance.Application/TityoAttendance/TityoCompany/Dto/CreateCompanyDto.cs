using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TityoAttendance.TityoAttendance.TityoCompany.Dto
{
    [AutoMapTo(typeof(Company))]
    public class CreateCompanyDto
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
    }
}
