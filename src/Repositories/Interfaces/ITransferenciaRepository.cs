using desafio.api.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace desafio.api.Repositories.Interfaces
{
    public interface ITransferenciaRepository
    {
        Task AdicionarTransaction(TransferenciaEntity entityEntity);

        Task SalvarAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
