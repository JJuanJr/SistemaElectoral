using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaElectoral.Datos;
using SistemaElectoral.Datos.Persona;
using SistemaElectoral.Datos.Rol;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Controllers
{
    public class PersonaController : Controller
    {

        public IActionResult Index()
        {
            const string nombre_page = "Persona_Index01";
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

            List<PersonaModel> lista = PersonaData.Consultar();
            return View(lista);
        }

        public IActionResult Detalle(ulong id)
        {
            const string nombre_page = "Persona_Detalle01";
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

            PersonaModel modelo = PersonaData.Consultar(id);
            return View(modelo);
        }
        public IActionResult Nuevo()
        {
            const string nombre_page = "Persona_Nuevo01";
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

            List<RolModel> lista = RolData.Consultar();
            ViewData["Rol"] = lista;
            return View();
        }
        public IActionResult Guardar(PersonaModel modelo)
        {
            const string nombre_page = "Persona_Guardar01";
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

            PersonaData.Guardar(modelo);
            List<RolModel> lista = RolData.Consultar();
            ViewData["Rol"] = lista;
            return View("Nuevo");
        }
    }
}
