namespace WebApp.Model;

public class Booking
{
    public Guid Id { get; set; }
    public ICollection<Passenger> Passengers { get; set; } = [];
    public Flight Flight { get; set; }
    public Guid FlightId { get; set; }
}