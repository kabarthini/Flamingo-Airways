using FlamingoAirways.Api.Models;

namespace FlamingoAirways.Api.Data
{
    public static class DbSeeder
    {
        public static void Seed(PaymentContext context)
        {
            if (!context.BankAccounts.Any())
            {
                context.BankAccounts.AddRange(
                 
                    new BankAccount { CardNumber = "4111111111111111", CardType = "Credit", Expiry = "12/25", Cvv = "123", Balance = 10000 },
               
                    new BankAccount { CardNumber = "4111111111111118", CardType = "Debit", Expiry = "11/24", Cvv = "456", Balance = 15000 },
                   
                    new BankAccount { CardNumber = "5500000000000004", CardType = "Credit", Expiry = "10/26", Cvv = "789", Balance = 20000 },
                
                    new BankAccount { CardNumber = "5555555555554444", CardType = "Debit", Expiry = "09/27", Cvv = "321", Balance = 12000 },
                
                    new BankAccount { CardNumber = "378282246310005", CardType = "Credit", Expiry = "08/26", Cvv = "1111", Balance = 25000 },
                 
                    new BankAccount { CardNumber = "6011111111111117", CardType = "Credit", Expiry = "07/28", Cvv = "222", Balance = 18000 },
                  
                    new BankAccount { CardNumber = "4000000000000002", CardType = "Debit", Expiry = "06/25", Cvv = "333", Balance = 500 }
                );
                context.SaveChanges();
            }
        }
    }
}
