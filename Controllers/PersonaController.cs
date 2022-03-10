using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
            PersonaModel persona = JsonConvert.DeserializeObject<PersonaModel>(TempData.Peek("Sesion").ToString());
            if (valor_permiso == -1)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (valor_permiso == 0 && persona.id != id)
            {
                return RedirectToAction("Index", "Home");
            }

            PersonaModel modelo = PersonaData.Consultar(id);

            ViewData["Rol"] = RolData.Consultar(modelo.fk_id_rol);
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
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(ulong id)
        {
            const string nombre_page = "Persona_Eliminar01";
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


            PersonaData.Eliminar(id);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(ulong id)
        {
            const string nombre_page = "Persona_Modificar01";
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
            ViewData["Rol"] = RolData.Consultar();
            return View(modelo);
        }

        public IActionResult Actualizar(PersonaModel modelo)
        {
            const string nombre_page = "Persona_Actualizar01";
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

            PersonaData.Actualizar(modelo);
            return RedirectToAction("Index");
        }
    }
}
