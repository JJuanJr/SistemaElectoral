using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class PermisoController : Controller
    {
        public IActionResult Index()
        {
            List<PermisoModel> lista = PermisoData.Consultar();
            return View(lista);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult Guardar(PermisoModel modelo)
        {
            PermisoData.Guardar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(uint id)
        {
            PermisoModel modelo = PermisoData.Consultar(id);
            return View(modelo);
        }

        public IActionResult Actualizar(PermisoModel modelo)
        {
            PermisoData.Actualizar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(uint id)
        {
            PermisoData.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
