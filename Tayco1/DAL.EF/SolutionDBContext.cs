using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DO.Objects;

namespace DAL.EF
{
    public partial class SolutionDBContext :  DbContext
    {

        public SolutionDBContext(DbContextOptions<SolutionDBContext> options) : base(options) { }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TipoCancha> TipoCancha { get; set; }
        public virtual DbSet<TipoEquipo> TipoEquipo { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.Property(e => e.AdministradorId).HasColumnName("AdministradorId");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NombreAdministrador)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono).HasColumnName("Telefono");

                entity.Property(e => e.Estado).HasColumnName("Estado");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Administrador_role");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.Property(e => e.EquipoId).HasColumnName("EquipoId");

                entity.Property(e => e.NombreEquipo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cantidad).HasColumnName("Cantidad");

                entity.Property(e => e.TipoEquipoId).HasColumnName("TipoEquipoID");

                entity.Property(e => e.Estado).HasColumnName("Estado");

                entity.HasOne(d => d.TipoEquipo)
                    .WithMany(p => p.Equipo)
                    .HasForeignKey(d => d.TipoEquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoEquipo");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.ReservaId).HasColumnName("ReservaId");

                entity.Property(e => e.FechaReserva).HasColumnType("date");

                entity.Property(e => e.Hora).HasColumnType("datetime");

                entity.Property(e => e.Estado).HasColumnName("Estado");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipo");

                entity.HasOne(d => d.TipoCancha)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.TipoCanchaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tipo_Cancha");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PK_dbo.Roles");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoCancha>(entity =>
            {
                entity.HasKey(e => e.TipoCanchaId).HasName("TipoCanchaId");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombreCancha)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoEquipo>(entity =>
            {
                entity.HasKey(e => e.TipoEquipoId).HasName("TipoEquipoId");

                entity.Property(e => e.NombreTipo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_dbo.Users");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono).HasColumnName("Telefono");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Estado).HasColumnName("Estado");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
