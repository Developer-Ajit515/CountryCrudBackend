using CountryCrud.Data;
using CountryCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using PaymentModel = CountryCrud.Models.Payment;
using Microsoft.Extensions.Options;

namespace CountryCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RazorpayOptions _razorpay;

        public PaymentController(
            ApplicationDbContext context,
            IOptions<RazorpayOptions> razorpay)
        {
            _context = context;
            _razorpay = razorpay.Value;
        }

        // GET : api/payment
        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _context.Payments
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return Ok(payments);
        }

        // GET : api/payment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // CREATE ORDER
        
        [HttpPost("create-order")]
        public IActionResult CreateOrder(CreateOrderRequest request)
        {
            try
            {
                RazorpayClient client =
                    new RazorpayClient(_razorpay.Key, _razorpay.Secret);

                Dictionary<string, object> options = new Dictionary<string, object>();

                // Razorpay amount is in paise
                options.Add("amount", request.Amount * 100);

                options.Add("currency", "INR");

                options.Add("receipt", Guid.NewGuid().ToString());

                Order order = client.Order.Create(options);

                return Ok(new
                {
                    key = _razorpay.Key,
                    orderId = order["id"].ToString(),
                    amount = order["amount"],
                    currency = order["currency"]
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // SAVE PAYMENT
        [HttpPost]
        public async Task<IActionResult> SavePayment(PaymentModel payment )
        {
            payment.TransactionId = "TXN-" + Guid.NewGuid().ToString("N")[..10].ToUpper();
            payment.PaymentStatus = "Success";
            payment.CreatedDate = DateTime.Now;

            _context.Payments.Add(payment);

            await _context.SaveChangesAsync();

            return Ok(payment);
        }

        // UPDATE PAYMENT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, PaymentModel payment )
        {
            if (id != payment.Id)
                return BadRequest();

            _context.Entry(payment).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(payment);
        }

        // DELETE PAYMENT
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
                return NotFound();

            _context.Payments.Remove(payment);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Payment deleted successfully."
            });
        }
    }
}
