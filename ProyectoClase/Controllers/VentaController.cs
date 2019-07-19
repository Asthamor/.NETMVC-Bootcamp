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
                return View();
            }
            return RedirectToAction("Index", "Login");
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
