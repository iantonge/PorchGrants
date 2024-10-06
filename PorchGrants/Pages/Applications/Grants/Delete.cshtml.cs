using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PorchGrants.Data;
using PorchGrants.Data.Models;

namespace PorchGrants.Pages.Applications.Grants
{
    public class DeleteModel : PageModel
    {
        private readonly PorchGrants.Data.ApplicationDbContext _context;

        public DeleteModel(PorchGrants.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grant Grant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grant = await _context.Grants.FirstOrDefaultAsync(m => m.GrantId == id);

            if (grant == null)
            {
                return NotFound();
            }
            else
            {
                Grant = grant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grant = await _context.Grants.FindAsync(id);
            if (grant != null)
            {
                Grant = grant;
                _context.Grants.Remove(Grant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
