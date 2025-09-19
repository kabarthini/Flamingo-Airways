namespace FlamingoAirways.Api.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public string? CardType { get; set; }
        public string? Expiry { get; set; }
        public string? Cvv { get; set; }
        public decimal Balance { get; set; }
    }
}
