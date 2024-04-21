using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Pages.Bookings;

public class ShowModel(DataRepository repository) : PageModel
{
    public Booking GetBooking { get; set; }

    public async Task<IActionResult> OnGet(Guid id)
    {
        Booking? booking = await repository.GetBookingById(id);
        if (booking is null) return NotFound();
        GetBooking = booking;
        return Page();
    }

}