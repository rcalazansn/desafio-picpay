using desafio.api.Models;

namespace desafio.api.DTOs
{
    public static class TransferenciaMapping
    {
        public static TransferenciaDto ToTransferenciaDto(this TransferenciaEntity transferencia)
            => new TransferenciaDto(
                transferencia.IdentificacaoTransacao,
                transferencia.Pagador,
                transferencia.Recebedor,
                transferencia.Valor
            );
    }
}
