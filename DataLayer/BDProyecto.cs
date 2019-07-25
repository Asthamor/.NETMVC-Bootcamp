namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BDProyecto : DbContext
    {
        public BDProyecto()
            : base("name=BDProyecto")
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<ProductosdeVenta> ProductosdeVenta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(e => e.sku)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.precio_venta)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Producto>()
                .Property(e => e.precio_compra)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Venta)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.usuario_vendedor);

            modelBuilder.Entity<Venta>()
                .Property(e => e.usuario_vendedor)
                .IsUnicode(false);

            modelBuilder.Entity<ProductosdeVenta>()
                .Property(e => e.sku)
                .IsUnicode(false);
        }
    }
}
