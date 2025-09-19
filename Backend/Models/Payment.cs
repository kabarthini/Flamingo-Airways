using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlamingoAirways.Api.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        public string PNR { get; set; }
        public string PassengerName { get; set; }
        public int PassengerCount { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

        public int FlightID { get; set; }
        public Flight Flight { get; set; }  
    }
}
