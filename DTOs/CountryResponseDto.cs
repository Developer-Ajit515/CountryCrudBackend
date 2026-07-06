
namespace CountryCrud.DTOs
{
    public class CountryResponseDto
    {
        public int Id { get; set; }

        public string CountryName { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}