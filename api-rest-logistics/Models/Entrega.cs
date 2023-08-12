namespace api_rest_logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Entrega")]
    public partial class Entrega
    {
        [Key]
        public int IdEntrega { get; set; }

        public int ClienteId { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaEntrega { get; set; }

        public int? BodegaId { get; set; }

        public int? PuertoId { get; set; }

        public int TransporteId { get; set; }

        public decimal? PrecioNormal { get; set; }

        public decimal? Descuento { get; set; }

        public decimal? PrecioFinal { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[a-zA-Z0-9]{10}$", ErrorMessage = "El número de guía debe ser alfanúmerico")]
        public string NumeroGuia { get; set; }

        [Required]
        [StringLength(10)]
        public string TipoEntrega { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Puerto Puerto { get; set; }
        public virtual Transporte Transporte { get; set; }
        public virtual Bodega Bodega { get; set; }

        public virtual ICollection<EntregaTipoProducto> EntregaTipoProducto { get; set; }
    
    }
}
