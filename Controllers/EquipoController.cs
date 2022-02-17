using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Data;
using SistemaElectoral.Models;
using System.Collections.Generic;

namespace SistemaElectoral.Controllers
{
    public class EquipoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inscriptos(int id)
        {
            List<PersonaModel> lista = EquipoData.ConsultarInscriptos(id);
            return View(lista);
        }
    }
}
