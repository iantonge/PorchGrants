using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PorchGrants.Data;
using PorchGrants.Data.Models;

namespace PorchGrants.Pages.Applications.Grants
{
    public class CreateModel : PageModel
    {
        private readonly PorchGrants.Data.ApplicationDbContext _context;

        public CreateModel(PorchGrants.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApplicationId"] = new SelectList(_context.Applications, "ApplicationId", "ApplicationId");
            return Page();
        }

        [BindProperty]
        public Grant Grant { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Grants.Add(Grant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
