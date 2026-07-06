namespace CountryCrud.DTOs
{
    public class CreateOrderRequestDto
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; } = "INR";

        public string Receipt { get; set; } = string.Empty;
    }
}