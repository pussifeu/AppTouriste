namespace AppTourist.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<site> site { get; set; }
        public virtual DbSet<visiteur> visiteur { get; set; }
        public virtual DbSet<visiter> visiter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<site>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<site>()
                .Property(e => e.Lieu)
                .IsUnicode(false);

            modelBuilder.Entity<site>()
                .HasMany(e => e.visiter)
                .WithRequired(e => e.site)
                .HasForeignKey(e => e.IdSite);

            modelBuilder.Entity<visiteur>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<visiteur>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<visiteur>()
                .HasMany(e => e.visiter)
                .WithRequired(e => e.visiteur)
                .HasForeignKey(e => e.IdVisiteur);
        }
    }
}
