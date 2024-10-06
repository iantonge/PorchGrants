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

namespace PorchGrants.Pages.Organisations
{
    public class EditModel : PageModel
    {
        private readonly PorchGrants.Data.ApplicationDbContext _context;

        public EditModel(PorchGrants.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Organisation Organisation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation =  await _context.Organisation.FirstOrDefaultAsync(m => m.OrganisationId == id);
            if (organisation == null)
            {
                return NotFound();
            }
            Organisation = organisation;
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

            _context.Attach(Organisation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganisationExists(Organisation.OrganisationId))
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

        private bool OrganisationExists(int id)
        {
            return _context.Organisation.Any(e => e.OrganisationId == id);
        }
    }
}
