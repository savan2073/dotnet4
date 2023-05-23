using FizzBuzzWeb.Data;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    [Authorize]
    public class OstatnioSzukaneModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OstatnioSzukaneModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public FizzBuzz FizzBuzz { get; set; }
        public IList<FizzBuzz> FizzBuzzes { get; set; }
        public void OnGet()
        {
            var Wynik = HttpContext.Session.GetString("Data");
            if(Wynik != null)
            {
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(Wynik);
            }
            var wyswietl = (from FizzBuzz 
                            in _context.FizzBuzz 
                            orderby FizzBuzz.Date descending 
                            select FizzBuzz).Take(20);
            FizzBuzzes = wyswietl.ToList();

        }
    }
}
