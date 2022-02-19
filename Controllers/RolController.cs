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

        public IActionResult Eliminar(int id)
        {
            RolData.Eliminar(id);
            List<RolModel> lista = RolData.Consultar();
            return View("Index", lista);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult Guardar(RolModel modelo)
        {
            RolData.Guardar(modelo);
            List<RolModel> lista = RolData.Consultar();
            return View("Index", lista);
        }

        public IActionResult Modificar(int id)
        {
            RolModel modelo = RolData.Consultar(id);
            return View(modelo);
        }

        public IActionResult Actualizar(RolModel modelo)
        {
            RolData.Actualizar(modelo);
            List<RolModel> lista = RolData.Consultar();
            return View("Index", lista);
        }
    }
}
