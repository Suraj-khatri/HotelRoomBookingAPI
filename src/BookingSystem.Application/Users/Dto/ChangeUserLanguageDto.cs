using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}