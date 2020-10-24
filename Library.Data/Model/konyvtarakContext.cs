using Microsoft.EntityFrameworkCore;

namespace Library.Data.Model
{
    public partial class konyvtarakContext : DbContext
    {
        public konyvtarakContext()
        {
        }

        public konyvtarakContext(DbContextOptions<konyvtarakContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Konyvtarak> Konyvtarak { get; set; }
        public virtual DbSet<Megyek> Megyek { get; set; }
        public virtual DbSet<Telepulesek> Telepulesek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=konyvtarak");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Konyvtarak>(entity =>
            {
                entity.ToTable("konyvtarak");

                entity.HasIndex(e => e.Irsz)
                    .HasName("fk_konyvtarTelepules");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cim)
                    .IsRequired()
                    .HasColumnName("cim")
                    .HasMaxLength(36);

                entity.Property(e => e.Irsz)
                    .IsRequired()
                    .HasColumnName("irsz")
                    .HasMaxLength(4);

                entity.Property(e => e.KonyvtarNev)
                    .IsRequired()
                    .HasColumnName("konyvtarNev")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IrszNavigation)
                    .WithMany(p => p.Konyvtarak)
                    .HasForeignKey(d => d.Irsz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_konyvtarTelepules");
            });

            modelBuilder.Entity<Megyek>(entity =>
            {
                entity.ToTable("megyek");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MegyeNev)
                    .IsRequired()
                    .HasColumnName("megyeNev")
                    .HasMaxLength(22);
            });

            modelBuilder.Entity<Telepulesek>(entity =>
            {
                entity.HasKey(e => e.Irsz)
                    .HasName("PRIMARY");

                entity.ToTable("telepulesek");

                entity.HasIndex(e => e.MegyeId)
                    .HasName("fk_telepulesMegye");

                entity.Property(e => e.Irsz)
                    .HasColumnName("irsz")
                    .HasMaxLength(4);

                entity.Property(e => e.MegyeId)
                    .HasColumnName("megyeId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TelepNev)
                    .IsRequired()
                    .HasColumnName("telepNev")
                    .HasMaxLength(19);

                entity.HasOne(d => d.Megye)
                    .WithMany(p => p.Telepulesek)
                    .HasForeignKey(d => d.MegyeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_telepulesMegye");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
