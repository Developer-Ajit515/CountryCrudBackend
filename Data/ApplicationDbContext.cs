using CountryCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}