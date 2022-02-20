using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class InstitucionController : Controller
    {
        public IActionResult Index()
        {
            InstitucionModel institucion = InstitucionData.Consultar();
            UbicacionModel ubicacion = UbicacionData.Consultar(institucion.fk_id_ubicacion);
            MunicipioModel municipio = MunicipioData.Consultar(ubicacion.fk_id_municipo);
            ViewData["Ubicacion"] = ubicacion;
            ViewData["Municipio"] = municipio;
            return View(institucion);
        }

        public IActionResult Modificar()
        {
            InstitucionModel modelo = InstitucionData.Consultar();
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Actualizar(InstitucionModel nuevo)
        {
            InstitucionData.Actualizar(nuevo);

            InstitucionModel modelo = InstitucionData.Consultar();
            ViewData["Ubicacion"] = UbicacionData.Consultar(modelo.fk_id_ubicacion);
            return View("Index", modelo);
        }
    }
}
