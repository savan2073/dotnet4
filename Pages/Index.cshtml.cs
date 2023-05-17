using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Data;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzBuzzContext _context;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        public Lista Lista = new Lista();
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public string AlertMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnPost()
        {

            var sessionData = HttpContext.Session.GetString("Data");
            if (sessionData != null)
            {
                Lista = JsonConvert.DeserializeObject<Lista>(sessionData);
            }



            if (FizzBuzz.BirthYear == 0)
            {
                ModelState.Remove("FizzBuzz.BirthYear");
                ModelState.AddModelError("FizzBuzz.BirthYear", "Pole Rok urodzenia nie może być puste");
            }
            if (ModelState.IsValid)
            {
                AlertMessage = "Podane wartości są nieprawidłowe";
                return Page();
            }
            
            if(FizzBuzz.BirthYear >= 1899 && FizzBuzz.BirthYear <= 2022)
            {
                if (FizzBuzz.LeapYear)
                {
                    AlertMessage = $"{FizzBuzz.FirstName} {FizzBuzz.LastName} urodził/a się w {FizzBuzz.BirthYear} roku. To był rok przestępny";
                }
                else
                {
                    AlertMessage = $"{FizzBuzz.FirstName} {FizzBuzz.LastName} urodził/a się w {FizzBuzz.BirthYear} roku. To nie był rok przestępny";
                }

                return Page();
            }
            else
            {
                return Page();
            }
            FizzBuzz.LeapYear = FizzBuzz.CheckLeapYear(FizzBuzz.BirthYear);
            FizzBuzz.Date = DateTime.Now;
            _context.FizzBuzz.Add(FizzBuzz);
            _context.SaveChanges();

            Lista.user.Add(FizzBuzz);
            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Lista));
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = "User";
            }
        }
    }
}