using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelLayer;
using DataLayer;
using Newtonsoft.Json;

namespace ProyectoClase.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logueo(UsuarioModel dataUsuario)
        {
            CD_Usuario cdUsuario = new CD_Usuario();
            var resultado = new JObject();
            UsuarioModel usuario = cdUsuario.ChecarUsuario(dataUsuario);
            if (usuario.Nombre != null)
            {
                Session["Usuario"] = usuario.Usuario;
                resultado["Exito"] = true;
                resultado["Usuario"] = JsonConvert.SerializeObject(usuario);
            }
            else
            {
                resultado["Exito"] = false;
                resultado["Error"] = true;
                resultado["Advertencia"] = "El usuario o contraseña son incorrectos";

            }

            return Content(resultado.ToString());
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}
