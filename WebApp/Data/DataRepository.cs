using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.DTOs;
using WebApp.Model;

namespace WebApp.Data;

public class DataRepository(DataContext context)
{
    public async Task<Flight?> GetFlightById(Guid id) => await context.Flights.Include(x => x.DepartureAirport).Include(x => x.ArrivalAirport).FirstOrDefaultAsync(x => x.Id == id);
    public async Task<Booking?> GetBookingById(Guid id) => await context.Bookings.Include(x => x.Flight).ThenInclude(x => x.ArrivalAirport).Include(x =>x.Flight).ThenInclude(x => x.DepartureAirport).Include(x => x.Passengers).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Flight>> SearchFlights(CreateFlightRequest request)
    {
        return await context.Flights.AsNoTracking().Where(x =>
            x.ArrivalAirport.Code.ToUpper().Equals(request.ArrivalCode.ToString().ToUpper()) &&
            x.DepartureAirport.Code.ToUpper().Equals(request.DepartureCode.ToString().ToUpper()) &&
            x.DepartureDateTime.Year == request.Date.Year &&
            x.DepartureDateTime.Month == request.Date.Month &&
            x.DepartureDateTime.Day == request.Date.Day).ToListAsync();
    }

    public async Task CreatePassengers(IEnumerable<Passenger> passengers)
    {
        await context.Passengers.AddRangeAsync(passengers);
        await context.SaveChangesAsync();
    }

    public async Task<Guid> CreateBooking(IEnumerable<Passenger> passengers, Guid flightId)
    {
        Guid bookingId = Guid.NewGuid();
        await context.Bookings.AddAsync(new Booking
        {
            Id = bookingId,
            Passengers = (ICollection<Passenger>)passengers,
            FlightId = flightId
        });
        await context.SaveChangesAsync();
        return bookingId;
    }

}
