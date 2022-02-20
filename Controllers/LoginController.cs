using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaElectoral.Datos.Login;
using SistemaElectoral.Datos.Persona;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            // Permiso
            if (TempData["Sesion"] != null)
            {
                TempData.Keep("Sesion");
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Invalido = false;
            return View();
        }

        public ActionResult Validar(LoginModel modelo)
        {
            bool flag = LoginData.Validar(modelo.user, modelo.password);
            if (flag)
            {
                TempData["Sesion"] = JsonConvert.SerializeObject(PersonaData.Consultar(modelo.user));
                TempData.Keep("Sesion");
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Invalido = true;
            return View("Index");
        }

        public IActionResult CerrarSesion()
        {
            TempData["Sesion"] = null;
            TempData.Keep("Sesion");
            ViewBag.Invalido = false;
            return View("Index");
        }

    }
}
