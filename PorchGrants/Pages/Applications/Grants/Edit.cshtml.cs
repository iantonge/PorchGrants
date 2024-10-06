using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PorchGrants.Data;
using PorchGrants.Data.Models;

namespace PorchGrants.Pages.Applications.Grants
{
    public class EditModel : PageModel
    {
        private readonly PorchGrants.Data.ApplicationDbContext _context;

        public EditModel(PorchGrants.Data.ApplicationDbContext context)
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

            var grant =  await _context.Grants.FirstOrDefaultAsync(m => m.GrantId == id);
            if (grant == null)
            {
                return NotFound();
            }
            Grant = grant;
           ViewData["ApplicationId"] = new SelectList(_context.Applications, "ApplicationId", "ApplicationId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Grant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrantExists(Grant.GrantId))
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

        private bool GrantExists(int id)
        {
            return _context.Grants.Any(e => e.GrantId == id);
        }
    }
}
