using desafio.api.Models;

namespace desafio.api.Repositories.Interfaces
{
    public interface ICarteiraRepository
    {
        Task AdicionarAsync(CarteiraEntity carteira);

        Task AtualizarAsync(CarteiraEntity carteira);

        Task<CarteiraEntity?> ObterPorCpfCnpj(string cpfCnpj, string email);

        Task<CarteiraEntity?> ObterPorId(int id);

        Task SalvarAsync();
    }
}
