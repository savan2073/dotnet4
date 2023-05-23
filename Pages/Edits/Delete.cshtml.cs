using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzWeb.Pages.Edits
{
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.ApplicationDbContext _context;

        public DeleteModel(FizzBuzzWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FizzBuzz = await _context.FizzBuzz.FirstOrDefaultAsync(m => m.Id == id);
            if(FizzBuzz == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FizzBuzz = await _context.FizzBuzz.FindAsync(id);
            if (String.Equals(FizzBuzz.UserMail, User.Identity.Name))
            {
                

                if(FizzBuzz != null)
                {
                    if(String.Equals(FizzBuzz.UserMail, User.Identity.Name))
                    {
                        _context.FizzBuzz.Remove(FizzBuzz);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
