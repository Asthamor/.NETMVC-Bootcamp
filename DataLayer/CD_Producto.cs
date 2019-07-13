using ModelLayer;
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
            
            using (var context = new BDProyectoMVCEntities())
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
                var productos = context.Producto.ToList();
                return productos;
            }
        }

        public Producto GetProductoBySKU(string ProductSKU) {
            using (var context = new BDProyectoMVCEntities()) {
                var producto = context.Producto.First(p => p.sku == ProductSKU);
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
            using (var context = new BDProyectoMVCEntities()) {
                var productos = context.Producto.Where(p => p.nombre.ToLower().Contains(query.ToLower())).ToList();
                return productos;
            }
        }

    }
}
