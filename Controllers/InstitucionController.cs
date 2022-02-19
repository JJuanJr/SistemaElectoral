using Microsoft.AspNetCore.Mvc;

namespace SistemaElectoral.Controllers
{
    public class InstitucionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
