
using CountryCrud.DTOs;

namespace CountryCrud.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentResponseDto>> GetAllPaymentsAsync();

        Task<PaymentResponseDto?> GetPaymentByIdAsync(int id);

        Task<PaymentResponseDto> CreatePaymentAsync(CreatePaymentDto dto);

        Task<PaymentResponseDto?> UpdatePaymentAsync(UpdatePaymentDto dto);

        Task<bool> DeletePaymentAsync(int id);
    }
}

