namespace CountryCrud.Models
{
  
        public class Payment
        {
            public int Id { get; set; }

            public string CustomerName { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public decimal Amount { get; set; }

            public string TransactionId { get; set; } = string.Empty;

            public string PaymentMethod { get; set; } = string.Empty;

            public string PaymentStatus { get; set; } = string.Empty;

            public DateTime CreatedDate { get; set; }
        }
    }
