using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FizzBuzzWeb.Models
{
    public class FizzBuzz
    {
        public int Id { get; set; }
        public string Wynik { get; set; } = "-";
        public DateTime Date { get; set; }
        [Display (Name = "Rok urodzenia")]
        [Required(ErrorMessage = "Pole Rok Urodzenia jest obowiązkowe"),
            Range (1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int BirthYear { get; set; }

        [RegularExpression("[A-Za-z]*", ErrorMessage = "Nie możesz używać liczb oraz znaków specjalnych")]
        [Required(ErrorMessage = "Pole Imię nie może być puste")]
        [Display (Name = "Imię")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [StringLength(maximumLength: 100), Column(TypeName ="varchar(100)")]
        public string? LastName { get; set; }

        public bool LeapYear { get; set; }

        public string? UserMail { get; set; }

        public bool CheckLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            else
                return false;
        }



    }
}
