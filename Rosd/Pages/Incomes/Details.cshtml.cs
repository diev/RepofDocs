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

namespace Rosd.Pages.Incomes
{
    public class DetailsModel : PageModel
    {
        private readonly Rosd.Data.ApplicationDbContext _context;

        public DetailsModel(Rosd.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Income Income { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Income = await _context.Incomes.FirstOrDefaultAsync(m => m.Id == id);

            if (Income == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
