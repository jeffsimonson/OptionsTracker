using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OptionsTracker.Data;
using OptionsTracker.Models;
using System.Threading.Tasks;

namespace OptionsTracker.Pages.Trades
{
    public class DeleteModel : PageModel
    {
        private readonly OptionsTrackerContext _context;

        public DeleteModel(OptionsTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trade Trade { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trade = await _context.Trades.FirstOrDefaultAsync(m => m.ID == id);

            if (Trade == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trade = await _context.Trades.FindAsync(id);

            if (Trade != null)
            {
                _context.Trades.Remove(Trade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
