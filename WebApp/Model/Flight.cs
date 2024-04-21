namespace WebApp.Model;

public class Flight
{
    public Guid Id { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public TimeOnly Duration { get; set; }
    public Guid DepartureId { get; set; }
    public Airport DepartureAirport { get; set; }
    public Guid ArrivalId { get; set; }
    public Airport ArrivalAirport { get; set; }
}