using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Clase base para el acceso a datos.
/// Toda clase que acceda a datos debe extender esta clase.
/// </summary>
namespace DataAccess
{
    public class BaseData
    {
        internal SimpleAuthDBContext _simpleAuthDBContext;

        protected BaseData()
        {
            _simpleAuthDBContext = new SimpleAuthDBContext();
        }
    }


    /// <summary>
    /// Clase de acceso a datos.
    /// </summary>
    internal class SimpleAuthDBContext : DbContext
    {
        public SimpleAuthDBContext()
        {
        }

        public SimpleAuthDBContext(DbContextOptions<SimpleAuthDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Funcion> Funcion { get; set; }
        public virtual DbSet<LoginLog> LoginLog { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolFuncion> RolFuncion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioLogin> UsuarioLogin { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DANIELPC\\SQLSERVER2012;Database=SimpleAuthDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.Property(e => e.FuncionId)
                    .HasColumnName("funcionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fechaAlta")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.Property(e => e.UsuarioAltaId).HasColumnName("usuarioAltaID");

                entity.Property(e => e.UsuarioBajaId).HasColumnName("usuarioBajaID");

                entity.Property(e => e.UsuarioModificacionId).HasColumnName("usuarioModificacionID");
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.Property(e => e.LoginLogId).HasColumnName("loginLogID");

                entity.Property(e => e.Error).HasColumnName("error");

                entity.Property(e => e.Exitoso).HasColumnName("exitoso");

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fechaAlta")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioLoginLogId).HasColumnName("usuarioLoginLogID");

                entity.HasOne(d => d.UsuarioLogin)
                    .WithMany(p => p.LoginLog)
                    .HasForeignKey(d => d.UsuarioLoginLogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoginLog_UsuarioLogin");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.RolId).HasColumnName("rolID");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fechaAlta")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100);

                entity.Property(e => e.UsuarioAltaId).HasColumnName("usuarioAltaID");

                entity.Property(e => e.UsuarioBajaId).HasColumnName("usuarioBajaID");

                entity.Property(e => e.UsuarioModificacionId).HasColumnName("usuarioModificacionID");
            });

            modelBuilder.Entity<RolFuncion>(entity =>
            {
                entity.HasIndex(e => new { e.RolId, e.FuncionId })
                    .HasName("UK_RolFuncion")
                    .IsUnique();

                entity.Property(e => e.RolFuncionId).HasColumnName("rolFuncionID");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fechaAlta")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FuncionId).HasColumnName("funcionID");

                entity.Property(e => e.RolId).HasColumnName("rolID");

                entity.Property(e => e.UsuarioAltaId).HasColumnName("usuarioAltaID");

                entity.Property(e => e.UsuarioBajaId).HasColumnName("usuarioBajaID");

                entity.Property(e => e.UsuarioModificacionId).HasColumnName("usuarioModificacionID");

                entity.HasOne(d => d.Funcion)
                    .WithMany(p => p.RolFuncion)
                    .HasForeignKey(d => d.FuncionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolFuncion_Funcion");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolFuncion)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolFuncion_Rol");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId).HasColumnName("usuarioID");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fechaAlta")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(20);

                entity.Property(e => e.Perfil).HasColumnName("perfil");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(20);

                entity.Property(e => e.UsuarioAltaId).HasColumnName("usuarioAltaID");

                entity.Property(e => e.UsuarioBajaId).HasColumnName("usuarioBajaID");

                entity.Property(e => e.UsuarioModificacionId).HasColumnName("usuarioModificacionID");
            });

            modelBuilder.Entity<UsuarioLogin>(entity =>
            {
                entity.HasKey(e => e.UsuarioLoginId);

                entity.Property(e => e.UsuarioLoginId).HasColumnName("usuarioLoginID");

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fechaAlta")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdentificadorExterno).HasColumnName("identificadorExterno");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombreUsuario")
                    .HasMaxLength(30);

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Proveedor)
                    .HasColumnName("proveedor")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioAltaId).HasColumnName("usuarioAltaID");

                entity.Property(e => e.UsuarioBajaId).HasColumnName("usuarioBajaID");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioID");

                entity.Property(e => e.UsuarioModificacionId).HasColumnName("usuarioModificacionID");

                entity.Property(e => e.Validado).HasColumnName("validado");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioLogin)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioLogin_Usuario");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.HasIndex(e => new { e.RolId, e.UsuarioId })
                    .HasName("UK_UsuarioRol")
                    .IsUnique();

                entity.Property(e => e.UsuarioRolId).HasColumnName("usuarioRolID");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fechaAlta")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.RolId).HasColumnName("rolID");

                entity.Property(e => e.UsuarioAltaId).HasColumnName("usuarioAltaID");

                entity.Property(e => e.UsuarioBajaId).HasColumnName("usuarioBajaID");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioID");

                entity.Property(e => e.UsuarioModificacionId).HasColumnName("usuarioModificacionID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioRol_Rol");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioRol_Usuario");
            });

          //  OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

