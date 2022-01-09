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
    public class IndexModel : PageModel
    {
        private readonly Rosd.Data.ApplicationDbContext _context;

        public IndexModel(Rosd.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Income> Income { get;set; }

        public async Task OnGetAsync()
        {
            Income = await _context.Incomes.ToListAsync();
        }
    }
}
