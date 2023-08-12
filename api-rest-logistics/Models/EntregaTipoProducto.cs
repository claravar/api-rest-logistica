namespace api_rest_logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EntregaTipoProducto")]
    public partial class EntregaTipoProducto
    {
        [Key]
        public int IdEntregaTipoProducto { get; set; }

        public int EntregaId { get; set; }

        public int TipoProductoId { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public decimal Total { get; set; }

        public virtual Entrega Entrega { get; set; }

        public virtual TipoProducto TipoProducto { get; set; }
    }
}
