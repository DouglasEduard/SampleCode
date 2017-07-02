namespace Prospectivos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProspectivoContato")]
    public partial class ProspectivoContato
    {
        public int ProspectivoContatoId { get; set; }

        [Display(Name = "Prospective")]
        public int ProspectivoCod { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Date")]
        public DateTime? ProspectivoContatoData { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Content")]
        public string ProspectivoContatoDetalhes { get; set; }

        [Display(Name = "School management")]
        public bool? ProspectivoContatoGestaoEscolas { get; set; }

        [Display(Name = "Library")]
        public bool? ProspectivoContatoBiblioteca { get; set; }

        [Display(Name = "Free courses")]
        public bool? ProspectivoContatoCursosLivres { get; set; }

        [Display(Name = "Collection")]
        public bool? ProspectivoContatoAcervo { get; set; }

        public virtual Prospectivo Prospectivo { get; set; }
    }
}
