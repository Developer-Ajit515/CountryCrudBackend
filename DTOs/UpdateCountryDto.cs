
using System.ComponentModel.DataAnnotations;

namespace CountryCrud.DTOs
{
    public class UpdateCountryDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Country Name is required.")]
        [StringLength(100, ErrorMessage = "Country Name cannot exceed 100 characters.")]
        public string CountryName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country Code is required.")]
        [StringLength(10, ErrorMessage = "Country Code cannot exceed 10 characters.")]
        public string CountryCode { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
