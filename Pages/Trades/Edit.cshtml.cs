using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OptionsTracker.Data;
using OptionsTracker.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsTracker.Pages.Trades
{
    public class EditModel : PageModel
    {
        private readonly OptionsTrackerContext _context;

        public EditModel(OptionsTrackerContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Trade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeExists(Trade.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TradeExists(int id)
        {
            return _context.Trades.Any(e => e.ID == id);
        }
    }
}
