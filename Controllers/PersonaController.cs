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
            List<PersonaModel> lista = PersonaData.Consultar();
            return View(lista);
        }


        public IActionResult Nuevo()
        {
            List<RolModel> lista = RolData.Consultar();
            ViewData["Rol"] = lista;
            return View();
        }
        
        public IActionResult Guardar(PersonaModel modelo)
        {
            PersonaData.Guardar(modelo);
            List<RolModel> lista = RolData.Consultar();
            ViewData["Rol"] = lista;
            return View("Nuevo");
        }
    }
}
