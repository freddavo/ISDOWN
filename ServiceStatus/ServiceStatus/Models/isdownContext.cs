﻿using System;
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

        public virtual DbSet<Dns> Dns { get; set; }
        public virtual DbSet<Historico> Historicos { get; set; }
        public virtual DbSet<Servico> Servicos { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=isdown.database.windows.net;Database=isdown;user id=isdown;password=projeto.1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dns>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__DNS__737584F741538A6E");

                entity.ToTable("DNS", "id");

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
                    .HasName("PK__Historic__067525E019F5FAD4");

                entity.ToTable("Historico", "id");

                entity.Property(e => e.NomeServico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataFalha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Falha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resolvido)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Servico__737584F72776B92D");

                entity.ToTable("Servico", "id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Health_State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Health_State");

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Maintenance)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tempo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Servico__737584F72776B92D");

                entity.ToTable("Admin", "id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Health_State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Health_State");

                entity.Property(e => e.Resolvido)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Tempo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
