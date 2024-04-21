namespace WebApp.Model;

public class Passenger
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}