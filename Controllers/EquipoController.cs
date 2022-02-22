using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Datos.Rol;
using SistemaElectoral.Models;
using System.Collections.Generic;

namespace SistemaElectoral.Controllers
{
    public class EquipoController : Controller
    {
        public IActionResult Index()
        {
            const string nombre_page = "Equipo_Index01";
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

            return View();
        }

        public IActionResult Inscriptos(int id)
        {
            const string nombre_page = "Equipo_Inscriptos01";
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

            List<PersonaModel> lista = EquipoData.ConsultarInscriptos(id);
            return View(lista);
        }
    }
}
