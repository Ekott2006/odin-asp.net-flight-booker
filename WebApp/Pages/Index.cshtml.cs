using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    public RedirectToPageResult OnGet()
    {
        return RedirectToPagePermanent("Flights");
    }
}
