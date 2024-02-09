using EjerciciosEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosEF.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class Ejercicio03Model:PageModel
    {
        public readonly MisDatos Datos;

        public Ejercicio03Model (MisDatos datos)
        {
            Datos = datos;
        }
        public void OnGet ()
        {
        }
    }
}
