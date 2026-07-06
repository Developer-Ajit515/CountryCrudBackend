
using CountryCrud.DTOs;

namespace CountryCrud.Services.Interfaces
{
    public interface IRazorpayService
    {
        Task<CreateOrderResponseDto> CreateOrderAsync(CreateOrderRequestDto request);

        Task<bool> VerifyPaymentAsync(VerifyPaymentDto request);
    }
}

