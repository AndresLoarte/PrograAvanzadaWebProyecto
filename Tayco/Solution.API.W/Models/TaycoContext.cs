using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.Models
{
    public partial class TaycoContext : DbContext
    {
        public TaycoContext()
        {
        }

        public TaycoContext(DbContextOptions<TaycoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Auditoria> Auditoria { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Observaciones> Observaciones { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TipoCancha> TipoCancha { get; set; }
        public virtual DbSet<TipoEquipo> TipoEquipo { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersInRoles> UsersInRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=FAMILIALU;Database=Tayco;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.Property(e => e.AdministradorId).HasColumnName("AdministradorID");

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.NombreAdministrador).HasMaxLength(50);

                entity.Property(e => e.PrimerApellido).HasMaxLength(50);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Administrador_usuario");
            });

            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.Property(e => e.AuditoriaId).HasColumnName("AuditoriaID");

                entity.Property(e => e.Accion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.ReservaId).HasColumnName("ReservaID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Reserva)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.ReservaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_auditoria_reservas");
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.Property(e => e.BitacoraId)
                    .HasColumnName("BitacoraID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccionSistema)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioAplicacion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Cliente_usuario");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.Property(e => e.EquipoId).HasColumnName("EquipoID");

                entity.Property(e => e.NombreEquipo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TipoEquipoId).HasColumnName("TipoEquipoID");

                entity.HasOne(d => d.TipoEquipo)
                    .WithMany(p => p.Equipo)
                    .HasForeignKey(d => d.TipoEquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipoEquipo");
            });

            modelBuilder.Entity<Observaciones>(entity =>
            {
                entity.Property(e => e.ObservacionesId).HasColumnName("ObservacionesID");

                entity.Property(e => e.Asunto)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.ReservaId).HasColumnName("ReservaID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.FechaReserva).HasColumnType("date");

                entity.Property(e => e.Hora).HasColumnType("datetime");

                entity.Property(e => e.TipoCanchaId).HasColumnName("TipoCanchaID");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cliente");

                entity.HasOne(d => d.TipoCancha)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.TipoCanchaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tipo_Cancha");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_dbo.Roles");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            modelBuilder.Entity<TipoCancha>(entity =>
            {
                entity.Property(e => e.TipoCanchaId).HasColumnName("TipoCanchaID");

                entity.Property(e => e.NombreCancha)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoEquipo>(entity =>
            {
                entity.Property(e => e.TipoEquipoId).HasColumnName("TipoEquipoID");

                entity.Property(e => e.NombreTipo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_dbo.Users");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            modelBuilder.Entity<UsersInRoles>(entity =>
            {
                entity.HasKey(e => new { e.RoleRoleId, e.UserUserId })
                    .HasName("PK_dbo.RoleUsers");

                entity.Property(e => e.RoleRoleId).HasColumnName("Role_RoleID");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.RoleRole)
                    .WithMany(p => p.UsersInRoles)
                    .HasForeignKey(d => d.RoleRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_RoleID_UserInRoles");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.UsersInRoles)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserID_UserInRoles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
