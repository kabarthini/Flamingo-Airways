using System.ComponentModel.DataAnnotations.Schema;

namespace FlamingoAirways.Api.Models
{
    public class Flight
    {
        public int FlightID { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime TravelDate { get; set; }
        public int AvailableSeats { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

     
        public ICollection<Payment> Payments { get; set; }
    }
}
