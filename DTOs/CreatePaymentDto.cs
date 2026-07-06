
using System.ComponentModel.DataAnnotations;

namespace CountryCrud.DTOs
{
    public class CreatePaymentDto
    {
        [Required(ErrorMessage = "Customer Name is required.")]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, 99999999, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Transaction Id is required.")]
        [StringLength(100)]
        public string TransactionId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Payment Method is required.")]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required(ErrorMessage = "Payment Status is required.")]
        [StringLength(50)]
        public string PaymentStatus { get; set; } = string.Empty;
    }
}
