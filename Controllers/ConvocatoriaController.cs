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

namespace SistemaElectoral.Controllers
{
    public class ConvocatoriaController : Controller
    {
        ConvocatoriaData datos = new ConvocatoriaData();
        public IActionResult Index()
        {
            List<Convocatoria> lista = datos.Consultar();
            return View(lista);
        }

        public IActionResult Eliminar(int id)
        {
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
            datos.Guardar(modelo);
            List<Convocatoria> lista = datos.Consultar();
            return View("Index", lista);
        }

        public IActionResult Modificar(int id)
        {
            Convocatoria modelo = datos.Consultar(id);
            ViewData["Cargo"] = CargoData.Consultar();
            ViewData["Eleccion"] = EleccionData.Consultar();
            return View(modelo);
        }

        public IActionResult Actualizar(Convocatoria modelo)
        {
            datos.Actualizar(modelo);
            return View("Modificar", modelo);
        }

        public IActionResult Detalle(int id)
        {
            Convocatoria modelo = datos.Consultar(id);
            return View(modelo);
        }

        public IActionResult Inscriptos(int id)
        {
            List<EquipoModel> lista = ConvocatoriaData.ListarInscriptos(id);
            return View(lista);
        }
    }
}
