using DataLayer;
using ModelLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ProyectoClase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usuario"] != null)
            {
                Session["HomeServed"] = true;
                return View();
            }
            return RedirectToAction("Index", "Login");

        }

        public ActionResult GetProducts()
        {
            if (Session["HomeServed"].Equals(true))
            {
                CD_Producto CdProducto = new CD_Producto();
                var resultado = new JObject();
                var productos = CdProducto.GetAllProducts();
                if (productos.Count <= 0)
                {
                    resultado["Exito"] = true;
                    resultado["Productos"] = JsonConvert.SerializeObject(productos);
                    resultado["Advertencia"] = "No se encontraron productos para mostrar";
                }
                else if (productos.Count >= 1)
                {
                    resultado["Exito"] = true;
                    resultado["Productos"] = JsonConvert.SerializeObject(productos);
                    resultado["Advertencia"] = "No se encontraron productos para mostrar";
                }
                else if (productos == null)
                {
                    resultado["Exito"] = false;
                    resultado["Error"] = true;
                    resultado["Mensaje"] = "Ocurrió un error al recuperar los datos de productos";
                }
                return Content(resultado.ToString());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SearchProductByName(string searchParam)
        {
            CD_Producto CdProducto = new CD_Producto();
            var resultado = new JObject();
            var productos = CdProducto.SearchProducts(searchParam);
            resultado["suggestions"] = JsonConvert.SerializeObject(productos);
            return Content(resultado.ToString());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult IrAgregarProducto() {
            if (Session["Usuario"] != null)
            {
                return View("AgregarProducto");
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult IrAgregarUsuario()
        {
            if (Session["Usuario"] != null)
            {
                return View("AgregarUsuario");
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult IrVenderProducto()
        {
            if (Session["Usuario"] != null)
            {
                return View("VenderProducto");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}