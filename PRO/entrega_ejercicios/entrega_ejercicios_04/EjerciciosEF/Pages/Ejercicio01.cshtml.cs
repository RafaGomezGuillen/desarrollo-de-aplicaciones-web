using EjerciciosEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosEF.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class Ejercicio01Model:PageModel
    {
        public readonly MisDatos Datos;

        public Ejercicio01Model (MisDatos datos)
        {
            Datos = datos;
        }

        public void OnGet ()
        {
        }
    }
}
