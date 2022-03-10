using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class EleccionController : Controller
    {
        public IActionResult Index()
        {
            List<EleccionModel> lista = EleccionData.Consultar();
            return View(lista);
        }

        public IActionResult Nuevo()
        {
            EleccionModel modelo = new EleccionModel();
            modelo.fecha_inicio = DateTime.Now;
            modelo.fecha_fin = DateTime.Now;
            return View(modelo);
        }

        public IActionResult Guardar(EleccionModel modelo)
        {
            EleccionData.Guardar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(uint id)
        {
            EleccionModel modelo = EleccionData.Consultar(id);
            return View(modelo);
        }

        public IActionResult Actualizar(EleccionModel modelo)
        {
            EleccionData.Actualizar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(uint id)
        {
            EleccionData.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
