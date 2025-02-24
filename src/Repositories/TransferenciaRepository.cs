using desafio.api.Context;
using desafio.api.Models;
using desafio.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace desafio.api.Repositories
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly DesafioPicPayDbContext _context;

        public TransferenciaRepository(DesafioPicPayDbContext context)
            => _context = context;

        public async Task AdicionarTransaction(TransferenciaEntity entityEntity)
            => await _context.Transferencias.AddAsync(entityEntity);

        public async Task SalvarAsync()
            => await _context.SaveChangesAsync();

        public async Task<IDbContextTransaction> BeginTransactionAsync()
            => await _context.Database.BeginTransactionAsync();
    }
}
