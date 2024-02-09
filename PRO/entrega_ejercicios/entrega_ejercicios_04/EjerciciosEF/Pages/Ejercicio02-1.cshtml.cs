using EjerciciosEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosEF.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class Ejercicio02_1Model : PageModel
    {
        public readonly MisDatos Datos;

        public Ejercicio02_1Model (MisDatos datos)
        {
            Datos = datos;
        }
        public void OnGet()
        {
        }
    }
}
