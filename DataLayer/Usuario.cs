namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Venta = new HashSet<Venta>();
        }

        [Key]
        [Column("usuario")]
        [StringLength(50)]
        public string usuario1 { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string apellidos { get; set; }

        public DateTime? fechaNacimiento { get; set; }

        public byte? genero { get; set; }

        [StringLength(255)]
        public string correo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
