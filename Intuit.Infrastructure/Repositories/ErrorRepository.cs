using Intuit.Domain.Entities;
using Intuit.Domain.Repositories;
using Intuit.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Intuit.Infrastructure.Repositories
{
    internal class ErrorRepository : ICreateOnlyRepository<Error>
    {

        private readonly IntuitChallengeContext? _context;

        public ErrorRepository(IntuitChallengeContext? context)
        {
            _context = context;
        }

        public async Task<Error> CreateOnlyAsync(Error payload)
        {
            await _context.Database.ExecuteSqlAsync($"CALL AddError({payload.Module}, {payload.ErrorText});");

            await _context.SaveChangesAsync();

            return payload;
        }
    }
}
