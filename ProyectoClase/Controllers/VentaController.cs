using DataLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoClase.Controllers
{
    public class VentaController : Controller
    {

        //GET: Venta/VenderProductos

        public ActionResult VenderProducto()
        {
            if (Session["Usuario"] != null)
            {
                CD_Venta CdVenta = new CD_Venta();
                ViewBag.Folio = CdVenta.GetNextFolio();
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult GetCart()
        {
            var carrito = new JObject();
            if (Session["Usuario"] != null)
            {
                CD_Producto CdProducto = new CD_Producto();
                if (Request.Cookies["Carrito"] != null)
                {
                    var productos = JObject.Parse(Server.UrlDecode(Request.Cookies["Carrito"].Value));
                    foreach (var item in productos)
                    {
                        var value = JObject.FromObject(CdProducto.GetProductoBySKU(item.Key));
                        value.Add("cantidad", item.Value);
                        carrito.Add(value["sku"].ToString(), value);
                    }
                }
                
            }
            return Content(carrito.ToString());
        }


        // POST: Venta/Create
        [HttpPost]
        public ActionResult Create(Venta DataVenta)
        {
            var result = new JObject();
            if (Session["Usuario"] != null)
            {
                try
                {
                    CD_Venta CdVenta = new CD_Venta();
                    var ventaCreada = CdVenta.RegistrarVenta(DataVenta);
                    if (ventaCreada >= 1)
                    {
                        result["success"] = true;
                        result["mensaje"] = "La venta se ha registrado";
                    }

                }
                catch (Exception e)
                {
                    result["success"] = false;
                    result["error"] = e.Message;
                }

            } else
            {
                result["success"] = false;
                result["error"] = "No tiene permisos suficientes para realizar esta acciòn";
            }
            return Content(result.ToString());
        }



    }
}
