using desafio.api.Models;

namespace desafio.api.DTOs
{
    public record TransferenciaDto
    (
        Guid identificacaoTransacao,
        CarteiraEntity pagador,
        CarteiraEntity recebedor, 
        decimal valorTransferido
    );
}
