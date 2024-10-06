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
    public class IndexModel : PageModel
    {
        private readonly PorchGrants.Data.ApplicationDbContext _context;

        public IndexModel(PorchGrants.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Application> Application { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Application = await _context.Applications
                .Include(a => a.Organisation).ToListAsync();
        }
    }
}
