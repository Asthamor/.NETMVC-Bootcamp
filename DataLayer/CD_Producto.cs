using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CD_Producto
    {
        public  List<Producto> GetAllProducts() {

            List<Producto> productos = new List<Producto>();
            
            using (var context = new BDProyecto())
            {
                /*
                List<ProductoModel> prodModel = context.Producto.Select(p => new ProductoModel
                {
                    SKU = p.sku,
                    Nombre = p.nombre,
                    Stock = p.stock,
                    PrecioCompra = p.precio_compra,
                    PrecioVenta = p.precio_venta
                }).ToList();
                return prodModel;
                */

                
                productos.AddRange(context.Producto.Include("ProductosdeVenta").ToList());
                return productos;
            }
        }

        public Producto GetProductoBySKU(string ProductSKU) {
            using (var context = new BDProyecto()) {
                var producto = context.Producto.Include("ProductosdeVenta").FirstOrDefault(p => p.sku == ProductSKU);
                /*ProductModel pm = new ProductModel(){
                 * SKU = producto.sku,
                 * Nombre = producto.nombre,
                 * Stock = producto.stock,
                 * PrecioVenta = producto.precioVenta,
                 * PrecioCompra = producto.precioCompra,
                 * }
                 return pm;*/
                return producto;
            }
        }

        public List<Producto> SearchProducts(string query){
            using (var context = new BDProyecto()) {
                var productos = context.Producto.Where(p => p.nombre.ToLower().Contains(query.ToLower())).ToList();
                return productos;
            }
        }

        public int CrearProducto(Producto producto)
        {
            using (var context = new BDProyecto())
            {
                var product = context.Producto.Add(producto);
                var result = context.SaveChanges(); 
                return result;
            }
            
        }
        public bool ExisteProducto(string productSKU)
        {
            using (var context = new BDProyecto())
            {
                var product = context.Producto.Find(productSKU);
                if (product != null)
                {
                    return true;
                }
                return false;
            }
        }

        public int BorrarProducto(Producto producto)
        {
            using (var contexto = new BDProyecto())
            {
                var product = contexto.Producto.Remove(producto);
                var result = contexto.SaveChanges();
                return result;
            }
        }

        public int BorrarProducto(string productSKU)
        {
            using (var contexto = new BDProyecto())
            {
                var product = contexto.Producto.Where(u => u.sku == productSKU).First();
                contexto.Producto.Remove(product);
                var result = contexto.SaveChanges();
                return result;
            }
        }

        public List<Producto> GetPaginaProductos(int productsPerPage, int pageNumber)
        {
            using (var contexto = new BDProyecto())
            {
                var products = contexto.Producto.Skip((pageNumber * productsPerPage)).Take(productsPerPage).ToList();
                return products;
            }
        }


    }
}
