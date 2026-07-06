using Microsoft.EntityFrameworkCore;
using CountryCrud.Data;
using CountryCrud.Models;
using CountryCrud.Repositories.Interfaces;

namespace CountryCrud.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries
                .AsNoTracking()
                .OrderBy(c => c.CountryName)
                .ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _context.Countries
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Country> AddAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<Country?> UpdateAsync(Country country)
        {
            var existing = await _context.Countries.FindAsync(country.Id);

            if (existing == null)
                return null;

            existing.CountryName = country.CountryName;
            existing.CountryCode = country.CountryCode;
            existing.IsActive = country.IsActive;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
                return false;

            _context.Countries.Remove(country);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsAsync(string countryCode)
        {
            return await _context.Countries
                .AnyAsync(c => c.CountryCode == countryCode);
        }
    }
}