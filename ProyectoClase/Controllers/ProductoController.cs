using DataLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
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
        public ActionResult Create(FormCollection productoData)
        {
            var result = new JObject();
            if (Session["Usuario"] != null)
            {
                try
                {
                    Producto product = new Producto()
                    {
                        nombre = Request.Form["nombre"],
                        sku = Request.Form["sku"],
                        stock = Int32.Parse(Request.Form["stock"]),
                        precio_compra = Decimal.Parse(Request.Form["precio_compra"]),
                        precio_venta = Decimal.Parse(Request.Form["precio_venta"]),
                    };
                    var uploadedImage = Request.Files["imagen"];
                    if (uploadedImage.ContentLength != 0)
                    {
                        product.imagen = new BinaryReader(uploadedImage.InputStream).ReadBytes(uploadedImage.ContentLength);
                    }
                    CD_Producto CdProducto = new CD_Producto();
                    var creado = CdProducto.CrearProducto(product);
                    if (creado >= 1)
                    {
                        result["success"] = true;
                        result["error"] = false;
                    }
                    else
                    {
                        result["success"] = true;
                        result["error"] = "No se guardaron cambios a la base de datos";
                    }
                }
                catch (DbEntityValidationException e)
                {
                    result["success"] = false;
                    result["error"] = "Error de validación";
                    result["log"] = e.Message;
                }
                catch (DbUpdateException e)
                {
                    result["success"] = false;
                }

            }
            else
            {
                result["success"] = false;
                result["error"] = "No se tienen los permisos necesarios para realizar esta acción";
            }


            return Content(result.ToString());

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

        // GET: Producto/DetalleDeProducto/5
        public ActionResult DetalleDeProducto(string id)
        {
            CD_Producto CdProducto = new CD_Producto();
            Producto producto = CdProducto.GetProductoBySKU(id);
            return View(producto);
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
