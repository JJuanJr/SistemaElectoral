using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaElectoral.Datos.Login;
using SistemaElectoral.Models;
using System.Diagnostics;

namespace SistemaElectoral.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Validar(LoginModel modelo)
        {
            bool flag = LoginData.Validar(modelo.user, modelo.password);
            if (flag)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

    }
}
