namespace api_rest_logistics.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bodega")]
    public partial class Bodega
    {
        [Key]
        public int IdBodega { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        public virtual ICollection<Entrega> Entrega { get; set; }
    }
}
