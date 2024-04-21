namespace WebApp.DTOs;

public class BookingRequest
{
    public int TicketNumber { get; set; }

    public Guid FlightId { get; set; }
}