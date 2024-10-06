﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PorchGrants.Data;
using PorchGrants.Data.Models;

namespace PorchGrants.Pages.Organisations
{
    public class DeleteModel : PageModel
    {
        private readonly PorchGrants.Data.ApplicationDbContext _context;

        public DeleteModel(PorchGrants.Data.ApplicationDbContext context)
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

            var organisation = await _context.Organisation.FirstOrDefaultAsync(m => m.OrganisationId == id);

            if (organisation == null)
            {
                return NotFound();
            }
            else
            {
                Organisation = organisation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation.FindAsync(id);
            if (organisation != null)
            {
                Organisation = organisation;
                _context.Organisation.Remove(Organisation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
