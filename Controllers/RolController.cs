using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SistemaElectoral.Data;
using SistemaElectoral.Datos.Rol;
using SistemaElectoral.Models;
using System.Collections.Generic;

namespace SistemaElectoral.Controllers
{
    public class RolController : Controller
    {
        public IActionResult Index()
        {
            const string nombre_page = "Rol_Index01";
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
            return View(lista);
        }

        public IActionResult Eliminar(uint id)
        {
            const string nombre_page = "Rol_Eliminar01";
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


            RolData.Eliminar(id);
            List<RolModel> lista = RolData.Consultar();
            return View("Index", lista);
        }

        public IActionResult Nuevo()
        {
            const string nombre_page = "Rol_Nuevo01";
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

            RolModel modelo = new RolModel();
            modelo.permisos = PermisoData.ListToSelectList();
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Guardar(RolModel modelo)
        {
            const string nombre_page = "Rol_Guardar01";
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

            RolData.Guardar(modelo);

            List<RolModel> lista = RolData.Consultar();
            return View("Index", lista);
        }

        public IActionResult Modificar(uint id)
        {
            const string nombre_page = "Rol_Modificar01";
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


            RolModel modelo = RolData.Consultar(id);
            return View(modelo);
        }

        public IActionResult Actualizar(RolModel modelo)
        {
            const string nombre_page = "Rol_Actualizar01";
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


            RolData.Actualizar(modelo);
            List<RolModel> lista = RolData.Consultar();
            return View("Index", lista);
        }
    }
}
