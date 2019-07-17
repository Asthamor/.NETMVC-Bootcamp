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
    public class ProductoController : Controller
    {
        // GET: Producto/AgregarProducto

        public ActionResult AgregarProducto()
        {
            if (Session["Usuario"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            CD_Producto CdProducto = new CD_Producto();
            Producto producto = new Producto()
            {
                nombre = collection.GetValue("nombre").ToString(),
            };
            return View();
        }

        
        //GET: Producto/SearchProductByName
        public ActionResult SearchProductByName(string searchParam)
        {
            CD_Producto CdProducto = new CD_Producto();
            var resultado = new JObject();
            var productos = CdProducto.SearchProducts(searchParam);
            resultado["suggestions"] = JsonConvert.SerializeObject(productos);
            return Content(resultado.ToString());
        }


        //GET: Producto/GetProducts
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


        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
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

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
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
