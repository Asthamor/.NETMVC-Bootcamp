namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            ProductosdeVenta = new HashSet<ProductosdeVenta>();
        }

        [Key]
        [StringLength(20)]
        public string sku { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        public int stock { get; set; }

        [Column(TypeName = "money")]
        public decimal precio_venta { get; set; }

        [Column(TypeName = "money")]
        public decimal precio_compra { get; set; }

        [Column(TypeName = "image")]
        public byte[] imagen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductosdeVenta> ProductosdeVenta { get; set; }
    }
}
