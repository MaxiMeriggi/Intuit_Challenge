namespace Intuit.Infrastructure.Models;

public partial class Clientes
{
    public ulong Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public string Cuit { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string TelefonoCelular { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
