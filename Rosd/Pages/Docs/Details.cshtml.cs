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

namespace Rosd.Pages.Docs
{
    public class DetailsModel : PageModel
    {
        private readonly Rosd.Data.ApplicationDbContext _context;

        public DetailsModel(Rosd.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Doc Doc { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doc = await _context.Docs.FirstOrDefaultAsync(m => m.Id == id);

            if (Doc == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
