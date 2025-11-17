using Intuit.Application.DTOs.Cliente;

namespace Intuit.Application.Services
{
    public interface IClienteService
    {
        Task<ClienteResponseDto> CreateAsync(ClienteRequestDto payload);
        Task<ClienteResponseDto> UpdateAsync(ClienteRequestDto payload);
        Task DeleteAsync(int id);
        Task<ClienteResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<ClienteResponseDto>> GetAllAsync();
        Task<List<ClienteResponseDto>> SearchAsync(string text);

    }
}
