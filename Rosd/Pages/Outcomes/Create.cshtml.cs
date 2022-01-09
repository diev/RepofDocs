#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rosd.Data;
using Rosd.Models;

namespace Rosd.Pages.Outcomes
{
    public class CreateModel : PageModel
    {
        private readonly Rosd.Data.ApplicationDbContext _context;

        public CreateModel(Rosd.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Outcome Outcome { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Outcomes.Add(Outcome);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
