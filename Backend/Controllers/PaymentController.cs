using Microsoft.AspNetCore.Mvc;
using FlamingoAirways.Api.Data;
using FlamingoAirways.Api.Models;

namespace FlamingoAirways.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentContext _context;

        public PaymentController(PaymentContext context)
        {
            _context = context;
        }

        [HttpGet("flight/{flightId}")]
        public IActionResult GetFlightDetails(int flightId)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.FlightID == flightId);

            if (flight == null)
                return NotFound("Flight not found.");

            return Ok(new
            {
                flight.FlightID,
                flight.FlightNumber,
                flight.Origin,
                flight.Destination,
                flight.TravelDate,
                flight.Price
            });
        }

     
        [HttpPost("pay/{flightId}")]
        public IActionResult ProcessPayment(int flightId, [FromBody] PaymentRequest request)
        {
           
            var flight = _context.Flights.FirstOrDefault(f => f.FlightID == flightId);
            if (flight == null)
                return BadRequest("Invalid flight selected.");

            decimal totalAmount = request.PassengerCount * flight.Price;

   
            var account = _context.BankAccounts.FirstOrDefault(a =>
                a.CardNumber == request.CardNumber &&
                a.Expiry == request.Expiry &&
                a.Cvv == request.Cvv);

            if (account == null)
                return BadRequest("Invalid card details.");
            if (account.Balance < totalAmount)
                return BadRequest("Insufficient funds.");

        
            account.Balance -= totalAmount;

  
            var booking = new Payment
            {
                PNR = "PNR" + DateTime.Now.Ticks,
                PassengerName = request.PassengerName,
                PassengerCount = request.PassengerCount,
                FlightID = flight.FlightID,
                Amount = totalAmount,
                Status = "Confirmed"
            };

            _context.Payment.Add(booking);
            _context.SaveChanges();

            return Ok(new
            {
                booking.PNR,
                booking.PassengerName,
                booking.PassengerCount,
                flight.FlightNumber,
                flight.TravelDate,
                booking.Amount,
                booking.Status
            });
        }
    }
}
