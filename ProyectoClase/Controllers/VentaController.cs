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
                    var venta = CdVenta.RegistrarVenta(DataVenta);
                    if (venta != null)
                    {

                        result["success"] = true;
                        result["folio"] = venta.idVenta;
                        result["venta"] = JsonConvert.SerializeObject(venta);
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

        // GET: Venta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Venta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Venta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Venta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
