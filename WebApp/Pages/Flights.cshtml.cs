using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.DTOs;
using WebApp.Helper;
using WebApp.Model;

namespace WebApp.Pages;
public class FlightsModel(ILogger<FlightsModel> logger, DataRepository repository) : PageModel
{
    [BindProperty(SupportsGet = true)] public CreateFlightRequest CreateFlightRequest { get; set; } = default!;
    public IEnumerable<Flight> FlightOptionsList { get; set; } = [];
    public int TicketNumber { get; set; }

    public IEnumerable<SelectListItem> StartDateSelectListItems { get; set; } =
    SeedDatabase.StartDates().Select(x =>
        new SelectListItem(DateOnly.FromDateTime(x).ToString(), DateOnly.FromDateTime(x).ToString()));

    public IEnumerable<SelectListItem> TicketNumberSelectListItems { get; set; } =
        ((int[])[1, 2, 3, 4, 5]).Select(i => new SelectListItem(i.ToString(), i.ToString()));

    public void OnGet()
    {
    }

    public async Task OnGetSearchAsync()
    {
        FlightOptionsList = await repository.SearchFlights(CreateFlightRequest);
        TicketNumber = CreateFlightRequest.TicketsNumber;
    }
}
