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

        //public virtual DbSet<Falha> Falhas { get; set; }
        public virtual DbSet<Historico> Historicos { get; set; }
        //public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Servico> Servicos { get; set; }
        //public virtual DbSet<DNS> DNSS { get; set; }
        //public virtual DbSet<Subscricao> Subscricaos { get; set; }
        //public object Historico { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=isdown.database.windows.net;Database=isdown;user id=isdown;password=projeto.1");
            }
        }

        // dotnet ef dbcontext scaffold "Server=isdown.database.windows.net;Database=isdown;user id=isdown;password=projeto.1" Microsoft.EntityFramework.SqlServer -o Models
        //dotnet ef dbcontext scaffold 'Server=isdown.database.windows.net;Database=isdown;user id=isdown;password=projeto.1' Microsoft.EntityFrameworkCore.SqlServer -o Models -c "DbContext"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            /*modelBuilder.Entity<Falha>(entity =>
            {
                entity.ToTable("Falha", "id");

                entity.Property(e => e.Id)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Tempo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("tempo");
            });*/

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => new { e.NomeServico, e.Falha })
                    .HasName("PK__Historic__F0D188F01ADC02AD");

                entity.ToTable("Historico", "id");

                entity.Property(e => e.NomeServico)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("idServico");

                entity.Property(e => e.Falha)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("idFalha");

                entity.Property(e => e.DataFalha)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("dataFalha");

 

               /* entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historico__idSer__6AEFE058");*/
            });

            /*modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa", "id");

                entity.Property(e => e.Id)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Apelido)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });*/

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Servico", "id");

                entity.Property(e => e.Name)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("Name");

                entity.Property(e => e.Health_State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            /*modelBuilder.Entity<Subscricao>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdServico })
                    .HasName("PK__Subscric__C4159BBE1639C307");

                entity.ToTable("Subscricao", "id");

                entity.Property(e => e.IdPessoa)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.IdServico)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Subscricaos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscrica__IdPes__4D5F7D71");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.Subscricaos)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscrica__IdSer__4E53A1AA");
            });*/

            modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
