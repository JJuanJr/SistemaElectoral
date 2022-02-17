using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Datos.Rol;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class RolController : Controller
    {
        public IActionResult Index()
        {
            List<RolModel> lista = RolData.Consultar();
            return View(lista);
        }
    }
}
