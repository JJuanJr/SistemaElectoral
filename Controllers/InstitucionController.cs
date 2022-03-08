using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Datos.Rol;
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
            const string nombre_page = "Institucion_Modificar01";
            // Permiso
            int valor_permiso = RolData.TienePermiso(TempData.Peek("Sesion"), nombre_page);
            if (valor_permiso == -1)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (valor_permiso == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            InstitucionModel modelo = InstitucionData.Consultar();
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Actualizar(InstitucionModel nuevo)
        {
            const string nombre_page = "Institucion_Actualizar01";
            // Permiso
            int valor_permiso = RolData.TienePermiso(TempData.Peek("Sesion"), nombre_page);
            if (valor_permiso == -1)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (valor_permiso == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            InstitucionData.Actualizar(nuevo);

            return RedirectToAction("Index");
        }
    }
}
