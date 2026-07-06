using AutoMapper;
using CountryCrud.DTOs;
using CountryCrud.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CountryCrud.Mappings
{
    public class MappingProfile : Profile { 
        public MappingProfile() { 

            CreateMap<CreateCountryDto, Country>();
            CreateMap<UpdateCountryDto, Country>(); 
            CreateMap<Country, CountryResponseDto>();
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>();
            CreateMap<Payment, PaymentResponseDto>();
        } 
    }
}
