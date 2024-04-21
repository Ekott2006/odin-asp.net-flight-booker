namespace WebApp.Model;

public class Airport
{
    public Guid Id { get; set; }
    public required string Code { get; set; }
    public ICollection<Flight> DepartureFlights { get; set; } = [];
    public ICollection<Flight> ArrivalFlights { get; set; } = [];
}