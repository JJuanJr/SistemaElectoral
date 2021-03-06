using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

            List<EquipoModel> lista = EquipoData.Consultar();

            return View(lista);
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

        public IActionResult Nuevo()
        {
            const string nombre_page = "Equipo_Nuevo01";
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

            ViewData["Partido"] = PartidoData.Consultar();
            return View();
        }

        public IActionResult Guardar(EquipoModel modelo)
        {
            const string nombre_page = "Equipo_Guardar01";
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


            EquipoData.Guardar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Entrar(uint id)
        {
            const string nombre_page = "Equipo_Entrar01";
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


            PersonaModel persona = JsonConvert.DeserializeObject<PersonaModel>(TempData.Peek("Sesion").ToString());
            EquipoData.Entrar(id, persona.id);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(uint id)
        {
            const string nombre_page = "Equipo_Modificar01";
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

            EquipoModel modelo = EquipoData.Consultar(id);
            ViewData["Partido"] = PartidoData.Consultar();
            return View(modelo);
        }

        public IActionResult Actualizar(EquipoModel modelo)
        {
            const string nombre_page = "Equipo_Actualizar01";
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

            EquipoData.Actualizar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(uint id)
        {
            const string nombre_page = "Equipo_Eliminar01";
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

            EquipoData.Eliminar(id);
            return RedirectToAction("Index");
        }

    }
}
