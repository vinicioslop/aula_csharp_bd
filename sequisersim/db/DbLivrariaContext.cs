using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace sequisersim.db;

public partial class DbLivrariaContext : DbContext
{
    public DbLivrariaContext()
    {
    }

    public DbLivrariaContext(DbContextOptions<DbLivrariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAutor> TbAutor { get; set; }

    public virtual DbSet<TbCategoria> TbCategoria { get; set; }

    public virtual DbSet<TbLivro> TbLivro { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=db_livraria", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TbAutor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PRIMARY");

            entity.ToTable("tb_autor");

            entity.Property(e => e.IdAutor)
                .ValueGeneratedNever()
                .HasColumnName("id_autor");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.NrFone)
                .HasMaxLength(15)
                .HasColumnName("nr_fone");
            entity.Property(e => e.Pais)
                .HasMaxLength(45)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<TbCategoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("tb_categoria");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("id_categoria");
            entity.Property(e => e.DsCategoria)
                .HasMaxLength(150)
                .HasColumnName("ds_categoria");
            entity.Property(e => e.NmCategoria)
                .HasMaxLength(45)
                .HasColumnName("nm_categoria");
        });

        modelBuilder.Entity<TbLivro>(entity =>
        {
            entity.HasKey(e => e.IdLivro).HasName("PRIMARY");

            entity.ToTable("tb_livro");

            entity.HasIndex(e => e.FkIdautor, "fk_idautor");

            entity.HasIndex(e => e.FkIdcategoria, "fk_idcategoria");

            entity.Property(e => e.IdLivro)
                .ValueGeneratedNever()
                .HasColumnName("id_livro");
            entity.Property(e => e.Ano)
                .HasColumnType("year")
                .HasColumnName("ano");
            entity.Property(e => e.DsLivro)
                .HasMaxLength(100)
                .HasColumnName("ds_livro");
            entity.Property(e => e.FkIdautor).HasColumnName("fk_idautor");
            entity.Property(e => e.FkIdcategoria).HasColumnName("fk_idcategoria");
            entity.Property(e => e.Titulo)
                .HasMaxLength(45)
                .HasColumnName("titulo");

            entity.HasOne(d => d.FkIdautorNavigation).WithMany(p => p.TbLivro)
                .HasForeignKey(d => d.FkIdautor)
                .HasConstraintName("tb_livro_ibfk_2");

            entity.HasOne(d => d.FkIdcategoriaNavigation).WithMany(p => p.TbLivro)
                .HasForeignKey(d => d.FkIdcategoria)
                .HasConstraintName("tb_livro_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
