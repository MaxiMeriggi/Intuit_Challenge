namespace Intuit.Application.DTOs.Cliente
{
    public class ClienteRequestDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string RazonSocial { get; set; } = null!;

        public string Cuit { get; set; } = null!;

        public DateOnly FechaNacimiento { get; set; }

        public string TelefonoCelular { get; set; } = null!;

        public string Email { get; set; } = null!;
    }

}
