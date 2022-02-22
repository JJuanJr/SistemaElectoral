using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaElectoral.Data;
using SistemaElectoral.Datos.Persona;
using SistemaElectoral.Datos.Rol;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            const string nombre_page = "Home_Index01";
            // Permiso
            int valor_permiso = RolData.TienePermiso(TempData.Peek("Sesion"), nombre_page);
            if (valor_permiso == -1)
            {
                return RedirectToAction("Index", "Login");
            } else if (valor_permiso == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["NombreInstitucion"] = InstitucionData.Consultar().nombre; 
            return View();
        }
    }
}