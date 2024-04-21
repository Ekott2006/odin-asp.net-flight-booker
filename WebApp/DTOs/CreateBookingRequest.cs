using System.ComponentModel.DataAnnotations;

namespace WebApp.DTOs;

public class CreateBookingRequest
{
    public int TicketNumber { get; set; }
    public Guid FlightId { get; set; }
    public IList<string> Email { get; set; } = [];
    [Required]
    public IList<string> Name { get; set; } = [];
}