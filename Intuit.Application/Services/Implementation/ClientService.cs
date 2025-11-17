using AutoMapper;
using Intuit.Application.DTOs.Cliente;
using Intuit.Application.Errors;
using Intuit.Domain.Entities;
using Intuit.Domain.Repositories;

namespace Intuit.Application.Services.Implementation
{
    public class ClientService : IClienteService
    {
        private readonly IRepository<Client> _repository;
        private readonly ISearchRepository<Client> _searchRepository;
        private readonly ICreateOnlyRepository<Error> _errorRepository;
        private readonly IMapper _mapper;
        public ClientService(IRepository<Client> repository,
                             ISearchRepository<Client> searchRepository,
                             IMapper mapper,
                             ICreateOnlyRepository<Error> errorRepository)
        {
            _repository = repository;
            _searchRepository = searchRepository;
            _mapper = mapper;
            _errorRepository = errorRepository;
        }

        public async Task<ClienteResponseDto> CreateAsync(ClienteRequestDto payload)
        {
            try
            {

                var clientToAdd = Client.Create(
                    payload.Nombre,
                    payload.Apellido,
                    payload.RazonSocial,
                    payload.Cuit,
                    payload.FechaNacimiento,
                    payload.TelefonoCelular,
                    payload.Email);

                var addedClient = await _repository.CreateAsync(clientToAdd);

                return _mapper.Map<ClienteResponseDto>(addedClient);
            }
            catch (Exception ex)
            {
                var error = Error.Create(nameof(ClientService), ex.Message);
                await _errorRepository.CreateOnlyAsync(error);
                throw ErrorFactory.ErrorOnRepositoryCall(error.Module, error.ErrorText);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                var error = Error.Create(nameof(ClientService), ex.Message);
                await _errorRepository.CreateOnlyAsync(error);
                throw ErrorFactory.ErrorOnRepositoryCall(error.Module, error.ErrorText);
            }
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetAllAsync()
        {
            try
            {
                var clientList = await _repository.GetAllAsync();
                return _mapper.Map<IEnumerable<ClienteResponseDto>>(clientList);
            }
            catch (Exception ex)
            {
                var error = Error.Create(nameof(ClientService), ex.Message);
                await _errorRepository.CreateOnlyAsync(error);
                throw ErrorFactory.ErrorOnRepositoryCall(error.Module, error.ErrorText);
            }
        }

        public async Task<ClienteResponseDto> GetByIdAsync(int id)
        {
            try
            {
                var client = await _repository.GetByIdAsync(id);
                return _mapper.Map<ClienteResponseDto>(client);
            }
            catch (Exception ex)
            {
                var error = Error.Create(nameof(ClientService), ex.Message);
                await _errorRepository.CreateOnlyAsync(error);
                throw ErrorFactory.ErrorOnRepositoryCall(error.Module, error.ErrorText);
            }
        }

        public async Task<List<ClienteResponseDto>> SearchAsync(string text)
        {
            try
            {
                var searchResult = await _searchRepository.SearchAsync(text);
                return _mapper.Map<List<ClienteResponseDto>>(searchResult);
            }
            catch (Exception ex)
            {
                var error = Error.Create(nameof(ClientService), ex.Message);
                await _errorRepository.CreateOnlyAsync(error);
                throw ErrorFactory.ErrorOnRepositoryCall(error.Module, error.ErrorText);
            }
        }

        public async Task<ClienteResponseDto> UpdateAsync(ClienteRequestDto payload)
        {
            try
            {
                var clientToUpdate = await _repository.GetByIdAsync(payload.Id);

                if (clientToUpdate == null)
                {
                    throw new Exception("Cliente no encontrado");
                }

                clientToUpdate.Modify(
                    payload.Nombre,
                    payload.Apellido,
                    payload.RazonSocial,
                    payload.Cuit,
                    payload.FechaNacimiento,
                    payload.TelefonoCelular,
                    payload.Email
                    );

                var updatedClient = await _repository.UpdateAsync(clientToUpdate);
                return _mapper.Map<ClienteResponseDto>(updatedClient);
            }
            catch (Exception ex)
            {
                var error = Error.Create(nameof(ClientService), ex.Message);
                await _errorRepository.CreateOnlyAsync(error);
                throw ErrorFactory.ErrorOnRepositoryCall(error.Module, error.ErrorText);
            }
        }

    }
}
