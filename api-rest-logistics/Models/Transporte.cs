namespace api_rest_logistics.Models
{
    
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
        [RegularExpression(@"^[a-zA-Z]{3}[0-9]{4}[a-zA-Z]{1}$", ErrorMessage = "El formato de flota debe ser AAA0000A")]
        public string Flota { get; set; }

        [StringLength(6)]
        [RegularExpression(@"^[a-zA-Z]{3}[0-9]{3}$", ErrorMessage = "El formato de placa debe ser AAA000")]
        public string Placa { get; set; }

        [Required]
        [StringLength(10)]
        public string TipoTransporte { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrega> Entrega { get; set; }
    }
}
