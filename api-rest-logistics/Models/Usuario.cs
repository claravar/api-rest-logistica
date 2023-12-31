namespace api_rest_logistics.Models
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
            Rol = new HashSet<Rol>();
        }

        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        public DateTime LastPasswordResetDate { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(2000)]
        public string Pass { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rol> Rol { get; set; }
    }
}
