using AutoMapper;
using Intuit.Domain.Entities;
using Intuit.Domain.Repositories;
using Intuit.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Intuit.Infrastructure.Repositories
{
    public class ClientRepository : IRepository<Client>, ISearchRepository<Client>
    {
        private readonly IntuitChallengeContext _context;
        private readonly IMapper _mapper;
        public ClientRepository(IntuitChallengeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Client> CreateAsync(Client payload)
        {
            var clientToAdd = _mapper.Map<Clientes>(payload);
            _context.Clientes.Add(clientToAdd);
            await _context.SaveChangesAsync();

            return _mapper.Map<Client>(clientToAdd);

        }

        public async Task DeleteAsync(int id)
        {
            var src = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == (ulong)id);

            if (src == null)
                throw new Exception("Cliente no encontrado");

            _context.Clientes.Remove(src);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var src = await _context.Clientes.ToListAsync();

            return _mapper.Map<List<Client>>(src);
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            var src = await _context.Clientes.FirstOrDefaultAsync(client => (int)client.Id == id);

            if (src == null)
                throw new Exception("Cliente no encontrado");

            return _mapper.Map<Client>(src);
        }

        public async Task<List<Client>> SearchAsync(string text)
        {
            var src = await _context.Clientes
                                    .Where(s => s.Nombre.Contains(text))
                                    .ToListAsync();

            return _mapper.Map<List<Client>>(src);
        }

        public async Task<Client> UpdateAsync(Client payload)
        {
            var src = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == payload.Id);

            if (src == null)
                throw new Exception("Cliente no encontrado");

            _mapper.Map(payload, src);

            await _context.SaveChangesAsync();

            return payload;
        }
    }
}
