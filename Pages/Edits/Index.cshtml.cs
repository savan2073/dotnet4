using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzWeb.Pages.Edits
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.ApplicationDbContext _context;
        public int i = 0;

        public IndexModel(FizzBuzzWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<FizzBuzz> FizzBuzz { get; set; }
        public async Task OngetAsync()
        {
            FizzBuzz = await _context.FizzBuzz.ToListAsync();
        }
    }
}
