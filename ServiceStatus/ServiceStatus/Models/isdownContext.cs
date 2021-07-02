using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class isdownContext : DbContext
    {
        public isdownContext()
        {
        }

        public isdownContext(DbContextOptions<isdownContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Dns> Dns { get; set; }
        public virtual DbSet<Historico> Historicos { get; set; }
        public virtual DbSet<Manutencao> Manutencaos { get; set; }
        public virtual DbSet<Servico> Servicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=isdown1.database.windows.net;Database=isdown;user id=isdown1;password=projeto.1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Admin__737584F7B0280F0A");

                entity.ToTable("Admin");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HealthState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Health_State");

                entity.Property(e => e.Tempo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dns>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__DNS__737584F7FAD23D35");

                entity.ToTable("DNS");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => new { e.NomeServico, e.DataFalha })
                    .HasName("PK__tmp_ms_x__067525E0F063EBC5");

                entity.ToTable("Historico");

                entity.Property(e => e.NomeServico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataFalha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resolvido)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manutencao>(entity =>
            {
                entity.HasKey(e => new { e.ServiceName, e.DataManutencao })
                    .HasName("PK__Manutenc__9D580686FD63F82E");

                entity.ToTable("Manutencao");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataManutencao)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Servico__737584F77E4CB655");

                entity.ToTable("Servico");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HealthState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Health_State");

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tempo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
