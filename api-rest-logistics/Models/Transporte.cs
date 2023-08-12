namespace api_rest_logistics.Models
{
    using api_rest_logistics.Validation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transporte")]
    public partial class Transporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transporte()
        {
            Entrega = new HashSet<Entrega>();
        }

        [Key]
        public int IdTransporte { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [StringLength(8)]
        [NumeroFlota]
        public string Flota { get; set; }

        [StringLength(6)]
        public string Placa { get; set; }

        [Required]
        [StringLength(10)]
        public string TipoTransporte { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrega> Entrega { get; set; }
    }
}
