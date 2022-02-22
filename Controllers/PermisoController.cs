using Microsoft.AspNetCore.Mvc;

namespace SistemaElectoral.Controllers
{
    public class PermisoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
