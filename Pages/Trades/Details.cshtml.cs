using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OptionsTracker.Data;
using OptionsTracker.Models;
using System.Threading.Tasks;

namespace OptionsTracker.Pages.Trades
{
    public class DetailsModel : PageModel
    {
        private readonly OptionsTrackerContext _context;

        public DetailsModel(OptionsTrackerContext context)
        {
            _context = context;
        }

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
    }
}
