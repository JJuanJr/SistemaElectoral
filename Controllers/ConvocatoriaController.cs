using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Models;
using System.Data;
using System;
using MySql.Data.MySqlClient;
using SistemaElectoral.Datos.Convocatoria;
using SistemaElectoral.Datos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using SistemaElectoral.Data;
using SistemaElectoral.Datos.Rol;
using Newtonsoft.Json;

namespace SistemaElectoral.Controllers
{
    public class ConvocatoriaController : Controller
    {
        public IActionResult Index()
        {
            const string nombre_page = "Convocatoria_Index01";
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

            List<Convocatoria> lista = ConvocatoriaData.Consultar();
            return View(lista);
        }

        public IActionResult Eliminar(int id)
        {
            const string nombre_page = "Convocatoria_Eliminar01";
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

            ConvocatoriaData.Eliminar(id);
            List<Convocatoria> lista = ConvocatoriaData.Consultar();
            return View("Index", lista);
        }

        public IActionResult Nuevo()
        {
            const string nombre_page = "Convocatoria_Nuevo01";
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


            ViewData["Cargo"] = CargoData.Consultar();

            ViewData["Eleccion"] = EleccionData.Consultar();

            Convocatoria modelo = new Convocatoria();
            modelo.fecha_inicio = DateTime.Now;
            modelo.fecha_fin = DateTime.Now;
            modelo.condiciones = CondicionData.ListToSelectList();
            return View(modelo);
        }

        public IActionResult Guardar(Convocatoria modelo)
        {
            const string nombre_page = "Convocatoria_Guardar01";
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
            modelo.fk_id_comite = ComiteData.ObtenerComiteSesion(persona).id;
            ConvocatoriaData.Guardar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(uint id)
        {
            const string nombre_page = "Convocatoria_Modificar01";
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


            Convocatoria modelo = ConvocatoriaData.Consultar(id);
            ViewData["Cargo"] = CargoData.Consultar();
            ViewData["Eleccion"] = EleccionData.Consultar();
            return View(modelo);
        }

        public IActionResult Actualizar(Convocatoria modelo)
        {
            const string nombre_page = "Convocatoria_Actualizar01";
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

            ConvocatoriaData.Actualizar(modelo);
            return RedirectToAction("Index");
        }

        public IActionResult Detalle(uint id)
        {
            const string nombre_page = "Convocatoria_Detalle01";
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

            Convocatoria modelo = ConvocatoriaData.Consultar(id);
            return View(modelo);
        }

        public IActionResult Inscriptos(int id)
        {
            const string nombre_page = "Convocatoria_Inscriptos01";
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

            List<EquipoModel> lista = ConvocatoriaData.ListarInscriptos(id);
            return View(lista);
        }

        public IActionResult Entrar(uint id)
        {
            const string nombre_page = "Convocatoria_Entrar01";
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
            ConvocatoriaData.Entrar(id, persona.id);
            return RedirectToAction("Index");
        }
    }
}
