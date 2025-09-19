using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FlamingoAirways.Api.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<PaymentContext>
    {
        public PaymentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaymentContext>();

           
            optionsBuilder.UseSqlServer(
               "Data Source=52.172.54.207,1433;Initial Catalog=FlamingoDb;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True"
            );

            return new PaymentContext(optionsBuilder.Options);
        }
    }
}
