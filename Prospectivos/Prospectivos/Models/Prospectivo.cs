namespace Prospectivos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prospectivo")]
    public partial class Prospectivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prospectivo()
        {
            ProspectivoContato1 = new HashSet<ProspectivoContato>();
        }

        [Key]
        [Display(Name = "Prospective")]
        public int ProspectivoCod { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string ProspectivoNome { get; set; }

        [StringLength(50)]
        [Display(Name = "Contact")]
        public string ProspectivoContato { get; set; }

        [StringLength(15)]
        [Display(Name = "Phone")]
        public string ProspectivoTelefone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProspectivoContato> ProspectivoContato1 { get; set; }

        public List<ProspectivoContato> Contatos;
    }
}
