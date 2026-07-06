using System.ComponentModel.DataAnnotations;

namespace CountryCrud.DTOs
{
    public class CountryRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string CountryName { get; set; }

        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; }

        public bool IsActive { get; set; }
    }
}
