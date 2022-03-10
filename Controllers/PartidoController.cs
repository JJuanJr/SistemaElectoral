using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class PartidoController : Controller
    {
        public IActionResult Index()
        {
            List<PartidoModel> lista = PartidoData.Consultar();
            return View(lista);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult Guardar(PartidoModel modelo)
        {
            PartidoData.Guardar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(uint id)
        {
            PartidoModel modelo = PartidoData.Consultar(id);
            return View(modelo);
        }

        public IActionResult Actualizar(PartidoModel modelo)
        {
            PartidoData.Actualizar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(uint id)
        {
            PartidoData.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
