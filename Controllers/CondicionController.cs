using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class CondicionController : Controller
    {
        public IActionResult Index()
        {
            List<CondicionModel> lista = CondicionData.Consultar();
            return View(lista);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult Guardar(CondicionModel modelo)
        {
            CondicionData.Guardar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(uint id)
        {
            CondicionModel modelo = CondicionData.Consultar(id);
            return View(modelo);
        }

        public IActionResult Actualizar(CondicionModel modelo)
        {
            CondicionData.Actualizar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(uint id)
        {
            CondicionData.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
