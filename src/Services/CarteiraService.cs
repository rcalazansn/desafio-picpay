using desafio.api.Core;
using desafio.api.Models;
using desafio.api.Repositories.Interfaces;
using desafio.api.Requests;
using desafio.api.Services.Interfaces;

namespace desafio.api.Services
{
    public class CarteiraService : ICarteiraService
    {
        private readonly ICarteiraRepository _repository;

        public CarteiraService(ICarteiraRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> ExecuteAsync(CarteiraRequest request)
        {
            var carteirajaExiste = await _repository.ObterPorCpfCnpj(request.CpfCnpj, request.Email);

            if (carteirajaExiste is not null)
                return Result<bool>.Failure("A Carteira já existe");

            var carteira = new CarteiraEntity(
                request.NomeCompleto,
                request.CpfCnpj,
                request.Email,
                request.Senha,
                request.TipoUsuario,
                request.SaldoConta);

            await _repository.AdicionarAsync(carteira);

            await _repository.SalvarAsync();

            return Result<bool>.Success(true);
        }
    }
}
