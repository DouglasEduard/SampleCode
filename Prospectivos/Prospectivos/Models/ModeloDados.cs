namespace Prospectivos.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloDados : DbContext
    {
        public ModeloDados()
            : base("name=ModeloDados")
        {
        }

        public virtual DbSet<Prospectivo> Prospectivo { get; set; }
        public virtual DbSet<ProspectivoContato> ProspectivoContato { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prospectivo>()
                .Property(e => e.ProspectivoNome)
                .IsUnicode(false);

            modelBuilder.Entity<Prospectivo>()
                .Property(e => e.ProspectivoContato)
                .IsUnicode(false);

            modelBuilder.Entity<Prospectivo>()
                .Property(e => e.ProspectivoTelefone)
                .IsUnicode(false);

            modelBuilder.Entity<Prospectivo>()
                .HasMany(e => e.ProspectivoContato1)
                .WithRequired(e => e.Prospectivo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProspectivoContato>()
                .Property(e => e.ProspectivoContatoDetalhes)
                .IsUnicode(false);
        }
    }
}
