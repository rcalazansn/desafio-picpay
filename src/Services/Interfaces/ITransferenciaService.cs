using desafio.api.Core;
using desafio.api.DTOs;
using desafio.api.Requests;

namespace desafio.api.Services.Interfaces
{
    public interface ITransferenciaService
    {
        Task<Result<TransferenciaDto>> ExecuteAsync(TransferenciaRequest request);
    }
}
