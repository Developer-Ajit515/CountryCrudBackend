
using CountryCrud.Data;
using CountryCrud.Models;
using CountryCrud.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CountryCrud.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }   

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Payment> AddAsync(Payment payment)
        {
            payment.CreatedDate = DateTime.Now;

            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        public async Task<Payment?> UpdateAsync(Payment payment)
        {
            var existing = await _context.Payments.FindAsync(payment.Id);

            if (existing == null)
                return null;

            existing.CustomerName = payment.CustomerName;
            existing.Email = payment.Email;
            existing.Amount = payment.Amount;
            existing.TransactionId = payment.TransactionId;
            existing.PaymentMethod = payment.PaymentMethod;
            existing.PaymentStatus = payment.PaymentStatus;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
                return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsTransactionAsync(string transactionId)
        {
            return await _context.Payments
                .AnyAsync(p => p.TransactionId == transactionId);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }

    }
}

