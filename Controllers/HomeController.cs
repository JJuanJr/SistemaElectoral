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
            string nombre_page = "Home_Index01";
            // Permiso
            if (!RolData.TienePermiso(TempData["Sesion"], nombre_page))
            {
                return RedirectToAction("Index", "Login");
            }
            TempData.Keep("Sesion");


            ViewData["NombreInstitucion"] = InstitucionData.Consultar().nombre; 
            return View();
        }
    }
}