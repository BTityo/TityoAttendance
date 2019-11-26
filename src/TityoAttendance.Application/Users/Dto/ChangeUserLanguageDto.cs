using System.ComponentModel.DataAnnotations;

namespace TityoAttendance.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}