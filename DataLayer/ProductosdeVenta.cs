namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductosdeVenta")]
    public partial class ProductosdeVenta
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idVenta { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string sku { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cantidad { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Venta Venta { get; set; }
    }
}
