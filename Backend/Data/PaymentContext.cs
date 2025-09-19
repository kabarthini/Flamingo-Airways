using FlamingoAirways.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FlamingoAirways.Api.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Flight)
                .WithMany(f => f.Payments)
                .HasForeignKey(p => p.FlightID);
        }
    }
}
