namespace FlamingoAirways.Api.Models
{
    public class PaymentRequest
    {
        public string PassengerName { get; set; }
        public int PassengerCount { get; set; }
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string Cvv { get; set; }
    }
}
