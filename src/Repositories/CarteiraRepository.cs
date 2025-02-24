using desafio.api.Context;
using desafio.api.Models;
using desafio.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace desafio.api.Repositories
{
    public class CarteiraRepository : ICarteiraRepository
    {
        private readonly DesafioPicPayDbContext _context;

        public CarteiraRepository(DesafioPicPayDbContext context)
            => _context = context;

        public async Task AdicionarAsync(CarteiraEntity carteira)
            => await _context.AddAsync(carteira);

        public async Task AtualizarAsync(CarteiraEntity carteira)
            => _context.Update(carteira);

        public async Task<CarteiraEntity?> ObterPorCpfCnpj(string cpfCnpj, string email)
            => await _context.Carteiras.FirstOrDefaultAsync(_ =>
                _.CpfCnpj.Equals(cpfCnpj) || _.Email.Equals(email));

        public async Task<CarteiraEntity?> ObterPorId(int id)
            => await _context.Carteiras.FindAsync(id);

        public async Task SalvarAsync()
            => await _context.SaveChangesAsync();
    }
}
