namespace CountryCrud.Models
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}
