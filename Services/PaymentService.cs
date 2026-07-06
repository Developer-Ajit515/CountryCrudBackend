
using AutoMapper;
using CountryCrud.DTOs;
using CountryCrud.Models;
using CountryCrud.Repositories.Interfaces;
using CountryCrud.Services.Interfaces;

namespace CountryCrud.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(
            IPaymentRepository paymentRepository,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<PaymentResponseDto>>(payments);
        }

        public async Task<PaymentResponseDto?> GetPaymentByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);

            if (payment == null)
                return null;

            return _mapper.Map<PaymentResponseDto>(payment);
        }

        public async Task<PaymentResponseDto> CreatePaymentAsync(CreatePaymentDto dto)
        {
            if (await _paymentRepository.ExistsTransactionAsync(dto.TransactionId))
            {
                throw new Exception("Transaction Id already exists.");
            }

            var payment = _mapper.Map<Payment>(dto);

            var result = await _paymentRepository.AddAsync(payment);

            return _mapper.Map<PaymentResponseDto>(result);
        }

        public async Task<PaymentResponseDto?> UpdatePaymentAsync(UpdatePaymentDto dto)
        {
            var existing = await _paymentRepository.GetByIdAsync(dto.Id);

            if (existing == null)
                return null;

            existing.CustomerName = dto.CustomerName;
            existing.Email = dto.Email;
            existing.Amount = dto.Amount;
            existing.TransactionId = dto.TransactionId;
            existing.PaymentMethod = dto.PaymentMethod;
            existing.PaymentStatus = dto.PaymentStatus;

            var updated = await _paymentRepository.UpdateAsync(existing);

            if (updated == null)
                return null;

            return _mapper.Map<PaymentResponseDto>(updated);
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            return await _paymentRepository.DeleteAsync(id);
        }
    }
}

