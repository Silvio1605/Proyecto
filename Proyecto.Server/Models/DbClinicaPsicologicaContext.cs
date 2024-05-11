using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Server.Models;

public partial class DbClinicaPsicologicaContext : DbContext
{
    public DbClinicaPsicologicaContext()
    {
    }

    public DbClinicaPsicologicaContext(DbContextOptions<DbClinicaPsicologicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblModulo> TblModulos { get; set; }

    public virtual DbSet<TblPermiso> TblPermisos { get; set; }

    public virtual DbSet<TblRol> TblRols { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

    public virtual DbSet<TblUsuarioPermiso> TblUsuarioPermisos { get; set; }

   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=DESKTOP-593MDQJ;Database=DB_ClinicaPsicologica;User Id=sa;Password=12345;TrustServerCertificate=true;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblModulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__TblModul__D9F153152CAE8D72");

            entity.Property(e => e.IdModulo).ValueGeneratedNever();
            entity.Property(e => e.NombreModulo).HasMaxLength(100);
        });

        modelBuilder.Entity<TblPermiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__TblPermi__0D626EC8F2F0824B");

            entity.Property(e => e.IdPermiso).ValueGeneratedNever();
            entity.Property(e => e.ModuloId).HasColumnName("ModuloID");
            entity.Property(e => e.NombrePermiso).HasMaxLength(100);

            entity.HasOne(d => d.Modulo).WithMany(p => p.TblPermisos)
                .HasForeignKey(d => d.ModuloId)
                .HasConstraintName("FK__TblPermis__Modul__3E52440B");
        });

        modelBuilder.Entity<TblRol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("Pk_IdRol");

            entity.ToTable("TblRol");

            entity.Property(e => e.DesRol)
                .HasMaxLength(36)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_IdUsser");

            entity.ToTable("TblUsuario");

            entity.Property(e => e.Correo)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.UltimaConexion).HasColumnType("datetime");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_IdRol");
        });

        modelBuilder.Entity<TblUsuarioPermiso>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.PermisoId }).HasName("PK__TblUsuar__0253EBE82CA8B08E");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.PermisoId).HasColumnName("PermisoID");

            entity.HasOne(d => d.Permiso).WithMany(p => p.TblUsuarioPermisos)
                .HasForeignKey(d => d.PermisoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TblUsuari__Permi__4222D4EF");

            entity.HasOne(d => d.Usuario).WithMany(p => p.TblUsuarioPermisos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TblUsuari__Usuar__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
