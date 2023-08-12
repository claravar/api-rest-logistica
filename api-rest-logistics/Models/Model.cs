using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace api_rest_logistics.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelLogistica")
        {
        }

        public virtual DbSet<Bodega> Bodega { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Entrega> Entrega { get; set; }
        public virtual DbSet<EntregaTipoProducto> EntregaTipoProducto { get; set; }
        public virtual DbSet<Puerto> Puerto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Transporte> Transporte { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bodega>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Bodega>()
                .Property(e => e.Direccion)
                .IsUnicode(false);
                    
            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Entrega)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.PrecioNormal)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.Descuento)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.PrecioFinal)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.NumeroGuia)
                .IsUnicode(false);

            modelBuilder.Entity<Entrega>()
                .Property(e => e.TipoEntrega)
                .IsUnicode(false);

            modelBuilder.Entity<Entrega>()
                .HasMany(e => e.EntregaTipoProducto)
                .WithRequired(e => e.Entrega)
                .HasForeignKey(e => e.EntregaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EntregaTipoProducto>()
                .Property(e => e.Precio)
                .HasPrecision(12, 2);

            modelBuilder.Entity<EntregaTipoProducto>()
                .Property(e => e.Total)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Puerto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Puerto>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Puerto>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Puerto>()
                .HasMany(e => e.Entrega)
                .WithOptional(e => e.Puerto)
                .HasForeignKey(e => e.PuertoId);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuario)
                .WithMany(e => e.Rol)
                .Map(m => m.ToTable("UsuarioRol").MapLeftKey("RolId").MapRightKey("UsuarioId"));

            modelBuilder.Entity<TipoProducto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoProducto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoProducto>()
                .Property(e => e.Precio)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TipoProducto>()
                .HasMany(e => e.EntregaTipoProducto)
                .WithRequired(e => e.TipoProducto)
                .HasForeignKey(e => e.TipoProductoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transporte>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Transporte>()
                .Property(e => e.Flota)
                .IsUnicode(false);

            modelBuilder.Entity<Transporte>()
                .Property(e => e.Placa)
                .IsUnicode(false);

            modelBuilder.Entity<Transporte>()
                .Property(e => e.TipoTransporte)
                .IsUnicode(false);

            modelBuilder.Entity<Transporte>()
                .HasMany(e => e.Entrega)
                .WithRequired(e => e.Transporte)
                .HasForeignKey(e => e.TransporteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Username)
                .IsUnicode(false);
        }
    }
}
