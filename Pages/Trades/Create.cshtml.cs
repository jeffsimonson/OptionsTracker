using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OptionsTracker.Models;
using System.Threading.Tasks;
using OptionsTracker.Data;

namespace OptionsTracker.Pages.Trades
{
    public class CreateModel : PageModel
    {
        private readonly OptionsTrackerContext _context;

        public CreateModel(OptionsTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Trade Trade { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trades.Add(Trade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
