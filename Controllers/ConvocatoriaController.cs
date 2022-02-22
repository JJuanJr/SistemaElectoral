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

namespace SistemaElectoral.Controllers
{
    public class ConvocatoriaController : Controller
    {
        ConvocatoriaData datos = new ConvocatoriaData();
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

            List<Convocatoria> lista = datos.Consultar();
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

            datos.Eliminar(id);
            List<Convocatoria> lista = datos.Consultar();
            return View("Index", lista);
        }

        public IActionResult Detalles()
        {
            return View();
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


            ViewData["Comite"] = ComiteData.Consultar();
            
            ViewData["Cargo"] = CargoData.Consultar();

            ViewData["Eleccion"] = EleccionData.Consultar();

            //string sql = "select id, fecha_inicio, fecha_fin from condicion";
            //DataTable condicion = Conexion.EjecutarSelectMysql(sql);
            //ViewData["Condicion"] = condicion;

            //ViewData["Condicion_elegidas"] = new List<CondicionModel>();

            return View();
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


            datos.Guardar(modelo);
            List<Convocatoria> lista = datos.Consultar();
            return View("Index", lista);
        }

        public IActionResult Modificar(int id)
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


            Convocatoria modelo = datos.Consultar(id);
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

            datos.Actualizar(modelo);
            return View("Modificar", modelo);
        }

        public IActionResult Detalle(int id)
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

            Convocatoria modelo = datos.Consultar(id);
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
    }
}
