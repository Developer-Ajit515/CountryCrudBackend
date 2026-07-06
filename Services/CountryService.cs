using AutoMapper;
using CountryCrud.DTOs;
using CountryCrud.Models;
using CountryCrud.Repositories.Interfaces;
using CountryCrud.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CountryCrud.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryResponseDto>> GetAllCountriesAsync()
        {
            var countries = await _countryRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CountryResponseDto>>(countries);
        }

        public async Task<CountryResponseDto?> GetCountryByIdAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
                return null;

            return _mapper.Map<CountryResponseDto>(country);
        }

        public async Task<CountryResponseDto> CreateCountryAsync(CreateCountryDto dto)
        {
            // Check duplicate Country Code
            if (await _countryRepository.ExistsAsync(dto.CountryCode))
                throw new Exception("Country Code already exists.");

            var country = _mapper.Map<Country>(dto);

            var result = await _countryRepository.AddAsync(country);

            return _mapper.Map<CountryResponseDto>(result);
        }

        public async Task<CountryResponseDto?> UpdateCountryAsync(UpdateCountryDto dto)
        {
            var existing = await _countryRepository.GetByIdAsync(dto.Id);

            if (existing == null)
                return null;

            existing.CountryName = dto.CountryName;
            existing.CountryCode = dto.CountryCode;
            existing.IsActive = dto.IsActive;

            var updated = await _countryRepository.UpdateAsync(existing);

            return _mapper.Map<CountryResponseDto>(updated);
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            return await _countryRepository.DeleteAsync(id);
        }

       
    }
}