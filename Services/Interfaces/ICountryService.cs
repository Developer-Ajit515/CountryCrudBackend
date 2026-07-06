using CountryCrud.DTOs;

namespace CountryCrud.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryResponseDto>> GetAllCountriesAsync();

        Task<CountryResponseDto?> GetCountryByIdAsync(int id);

        Task<CountryResponseDto> CreateCountryAsync(CreateCountryDto dto);

        Task<CountryResponseDto?> UpdateCountryAsync(UpdateCountryDto dto);

        Task<bool> DeleteCountryAsync(int id);
    }
}