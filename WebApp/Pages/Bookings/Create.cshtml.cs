using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.DTOs;
using WebApp.Model;

namespace WebApp.Pages.Bookings;

public class CreateModel(DataRepository repository) : PageModel
{
    [BindProperty(SupportsGet = true)] public int TicketNumber { get; set; }
    [BindProperty(SupportsGet = true)] public Guid FlightId { get; set; }
    [BindProperty] public CreateBookingRequest Request { get; set; }
    public Flight GetFlight { get; set; }

    public async Task<IActionResult> OnGet()
    {
        Flight? flight = await repository.GetFlightById(FlightId);
        if (flight is null) return NotFound();
        GetFlight = flight;
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (Request.Name.Any(string.IsNullOrEmpty) || Request.Email.Any(string.IsNullOrEmpty))
        {
            ModelState.AddModelError(string.Empty, "Fill Out all Name And Email");
        }
        if (!ModelState.IsValid) return Page();
        List<Passenger> passengers = [];
        passengers.AddRange(Request.Email.Select((t, i) => new Passenger
            { Id = Guid.NewGuid(), Name = Request.Name[i], Email = t }));
        await repository.CreatePassengers(passengers);
        Guid id = await repository.CreateBooking(passengers, Request.FlightId);
        return RedirectToPage("Show", new { Id = id });
    }
}