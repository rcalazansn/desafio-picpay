using desafio.api.Core;
using desafio.api.Requests;

namespace desafio.api.Services.Interfaces
{
    public interface ICarteiraService
    {
        Task<Result<bool>> ExecuteAsync(CarteiraRequest request);
    }
}
