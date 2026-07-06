using CountryCrud.Models;

namespace CountryCrud.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();

        Task<Country?> GetByIdAsync(int id);

        Task<Country> AddAsync(Country country);

        Task<Country?> UpdateAsync(Country country);

        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsAsync(string countryCode);
    }
}