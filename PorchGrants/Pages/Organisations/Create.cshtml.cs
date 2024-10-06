using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PorchGrants.Data;
using PorchGrants.Data.Models;

namespace PorchGrants.Pages.Organisations
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
            return Page();
        }

        [BindProperty]
        public Organisation Organisation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Organisation.Add(Organisation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
