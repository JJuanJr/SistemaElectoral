using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            List<CargoModel> lista = CargoData.Consultar();
            return View(lista);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult Guardar(CargoModel modelo)
        {
            CargoData.Guardar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(uint id)
        {
            CargoModel modelo = CargoData.Consultar(id);
            return View(modelo);
        }

        public IActionResult Actualizar(CargoModel modelo)
        {
            CargoData.Actualizar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(uint id)
        {
            CargoData.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
