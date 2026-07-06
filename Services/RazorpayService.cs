
using CountryCrud.DTOs;
using CountryCrud.Models;
using CountryCrud.Services.Interfaces;
using Microsoft.Extensions.Options;
using Razorpay.Api;
using System.Security.Cryptography;
using System.Text;

namespace CountryCrud.Services
{
    public class RazorpayService : IRazorpayService
    {
        private readonly RazorpayOptions _options;

        public RazorpayService(IOptions<RazorpayOptions> options)
        {
            _options = options.Value;
        }

        public async Task<CreateOrderResponseDto> CreateOrderAsync(CreateOrderRequestDto request)
        {
            RazorpayClient client = new RazorpayClient(
                _options.Key,
                _options.Secret);

            Dictionary<string, object> options = new()
            {
                { "amount", request.Amount * 100 }, // Razorpay expects paise
                { "currency", request.Currency },
                { "receipt", request.Receipt },
                { "payment_capture", 1 }
            };

            Order order = client.Order.Create(options);

            return await Task.FromResult(new CreateOrderResponseDto
            {
                OrderId = order["id"].ToString(),
                Key = _options.Key,
                Amount = request.Amount,
                Currency = request.Currency
            });
        }

        public async Task<bool> VerifyPaymentAsync(VerifyPaymentDto request)
        {
            string payload =
                request.RazorpayOrderId + "|" +
                request.RazorpayPaymentId;

            using var hmac = new HMACSHA256(
                Encoding.UTF8.GetBytes(_options.Secret));

            var hash = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(payload));

            var generatedSignature = BitConverter
                .ToString(hash)
                .Replace("-", "")
                .ToLower();

            return await Task.FromResult(
                generatedSignature == request.RazorpaySignature);
        }
    }
}

