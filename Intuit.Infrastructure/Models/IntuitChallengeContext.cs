using Microsoft.EntityFrameworkCore;

namespace Intuit.Infrastructure.Models;

public partial class IntuitChallengeContext : DbContext
{
    public IntuitChallengeContext()
    {
    }

    public IntuitChallengeContext(DbContextOptions<IntuitChallengeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Errores> Errores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Cuit, "cuit").IsUnique();

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Cuit)
                .HasMaxLength(20)
                .HasColumnName("cuit");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .HasColumnName("razon_social");
            entity.Property(e => e.TelefonoCelular)
                .HasMaxLength(30)
                .HasColumnName("telefono_celular");
        });

        modelBuilder.Entity<Errores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("errores");

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha");
            entity.Property(e => e.Modulo)
                .HasMaxLength(50)
                .HasColumnName("modulo");
            entity.Property(e => e.TextoError)
                .HasColumnType("text")
                .HasColumnName("texto_error");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
