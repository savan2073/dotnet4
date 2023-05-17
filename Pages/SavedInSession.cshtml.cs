using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<FizzBuzz> FizzBuzzx { get; set; }
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");

            if (!string.IsNullOrEmpty(Data))
            {
                try
                {
                FizzBuzzx = JsonConvert.DeserializeObject<List<FizzBuzz>>(Data);
            }
                catch(JsonSerializationException)
                {
                    var singleFizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(Data);
                    FizzBuzzx = new List<FizzBuzz> { singleFizzBuzz };
                }
            }
        }
    }
}