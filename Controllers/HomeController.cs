using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;

namespace SistemaElectoral.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["NombreInstitucion"] = InstitucionData.Consultar().nombre; 
            return View();
        }
    }
}