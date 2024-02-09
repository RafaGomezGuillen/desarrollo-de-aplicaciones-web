using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class Ejercicio01Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
