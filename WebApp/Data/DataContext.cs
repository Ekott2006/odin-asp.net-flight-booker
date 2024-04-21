using Microsoft.EntityFrameworkCore;
using WebApp.Helper;
using WebApp.Model;

namespace WebApp.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Airport>()
            .HasMany(e => e.ArrivalFlights)
            .WithOne(e => e.ArrivalAirport)
            .HasForeignKey(e => e.ArrivalId)
            .IsRequired();
        modelBuilder.Entity<Airport>()
            .HasMany(e => e.DepartureFlights)
            .WithOne(e => e.DepartureAirport)
            .HasForeignKey(e => e.DepartureId)
            .IsRequired();
            
        modelBuilder.Entity<Airport>().HasData(SeedDatabase.FakeAirportData());
        // Flight will be faked on startup
    }
}
