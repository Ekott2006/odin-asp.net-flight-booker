using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Model;
using WebApp.Model.Enum;

namespace WebApp.Helper;

public static class SeedDatabase
{
    public static IList<Airport> FakeAirportData()
    {
        List<Airport> airports = [];
        AirportCode[] airportCodes = Enum.GetValues<AirportCode>();

        airports.AddRange(airportCodes.Select(airportCode => new Airport
        {
            Id = Guid.NewGuid(),
            Code = airportCode.ToString().ToUpper()
        }));

        return airports;
    }

    public static List<Flight> FakeFlightData(IList<Airport> airports)
    {
        // To make it a DataService add all flight parameter and return airports
        List<Flight> flights = [];

        IList<DateTime> departureDateTimes = StartDates();
        Random random = new();

        foreach (Airport arrivalAirport in airports)
        {
            foreach (Airport departureAirport in airports)
            {
                if (arrivalAirport == departureAirport) continue;
                foreach (DateTime departureDateTime in departureDateTimes)
                {
                    int end = random.Next(2, 5);
                    TimeOnly duration = TimeOnly.FromTimeSpan(new TimeSpan(random.Next(1, 24), random.Next(59), 0));
                    for (int i = 0; i < end; i++)
                    {
                        Flight flight = new()
                        {
                            Id = Guid.NewGuid(),
                            DepartureDateTime = departureDateTime.AddHours(random.Next(24)),
                            Duration = duration,
                            DepartureId = departureAirport.Id,
                            ArrivalId = arrivalAirport.Id,
                        };
                        flights.Add(flight);
                    }
                }
            }
        }

        // return (airports, flights);
        return flights;
    }

    public static async Task SeedFlightData(DataContext context, int chunkSize = 100)
    {
        await context.Database.EnsureCreatedAsync();
        int count = await context.Flights.CountAsync();
        if (count != 0) return;
        IEnumerable<Airport> airports = await context.Airports.ToListAsync();
        List<Flight> flights = FakeFlightData(airports.ToList());
        int end = flights.Count;
        for (int i = 0; i < end; i += chunkSize)
        {
            int remaining = Math.Min(chunkSize, end - i);
            List<Flight> subFlights = flights.GetRange(i, remaining);
            await context.Flights.AddRangeAsync(subFlights);
            await context.SaveChangesAsync();
            Console.WriteLine("{0} records inserted", subFlights.Count);
        }
    }
    public static IList<DateTime> StartDates()
    {
        List<DateTime> dates = [];
        for (int i = 0; i < 10; i++)
        {
            dates.Add(DateTime.Today.AddDays(i));
        }

        return dates;
    }
}