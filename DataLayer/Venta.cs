namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Venta")]
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            ProductosdeVenta = new HashSet<ProductosdeVenta>();
        }

        [Key]
        public int idVenta { get; set; }

        [StringLength(50)]
        public string usuario_vendedor { get; set; }

        public int cliente { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductosdeVenta> ProductosdeVenta { get; set; }
    }
}
