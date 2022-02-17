using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Datos.Login;
using SistemaElectoral.Models;

namespace SistemaElectoral.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Invalido = "";
            return View();
        }

        public ActionResult Validar(LoginModel modelo)
        {
            bool flag = LoginData.Validar(modelo.user, modelo.password);
            if (flag)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Invalido = "¡Usuario no encontrado!";
            return View("Index");
        }

    }
}
