using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class ComiteController : Controller
    {
        public IActionResult Index()
        {
            List<ComiteModel> lista = ComiteData.Consultar();
            return View(lista);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult Guardar(ComiteModel modelo)
        {
            ComiteData.Guardar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(uint id)
        {
            ComiteModel modelo = ComiteData.Consultar(id);
            return View(modelo);
        }

        public IActionResult Actualizar(ComiteModel modelo)
        {
            ComiteData.Actualizar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(uint id)
        {
            ComiteData.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
