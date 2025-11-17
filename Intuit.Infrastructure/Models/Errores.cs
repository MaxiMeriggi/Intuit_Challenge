namespace Intuit.Infrastructure.Models;

public partial class Errores
{
    public ulong Id { get; set; }

    public string? Modulo { get; set; }

    public string TextoError { get; set; } = null!;

    public DateTime? Fecha { get; set; }
}
