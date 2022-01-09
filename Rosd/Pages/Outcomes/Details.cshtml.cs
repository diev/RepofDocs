#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rosd.Data;
using Rosd.Models;

namespace Rosd.Pages.Outcomes
{
    public class DetailsModel : PageModel
    {
        private readonly Rosd.Data.ApplicationDbContext _context;

        public DetailsModel(Rosd.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Outcome Outcome { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Outcome = await _context.Outcomes.FirstOrDefaultAsync(m => m.Id == id);

            if (Outcome == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
