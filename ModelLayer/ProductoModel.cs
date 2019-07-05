using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ProductoModel
    {
        public int SKU { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }

    }
}
