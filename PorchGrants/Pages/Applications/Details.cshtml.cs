using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PorchGrants.Data;
using PorchGrants.Data.Models;

namespace PorchGrants.Pages.Applications
{
    public class DetailsModel : PageModel
    {
        private readonly PorchGrants.Data.ApplicationDbContext _context;

        public DetailsModel(PorchGrants.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Application Application { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return NotFound();
            }
            else
            {
                Application = application;
            }
            return Page();
        }
    }
}
