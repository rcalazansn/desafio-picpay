using desafio.api.Core;

namespace desafio.api.Models
{
    public class TransferenciaEntity : BaseEntity
    {
        public TransferenciaEntity
        (
            int pagadorId, 
            int recebedorId, 
            decimal valor
        )
        {
            IdentificacaoTransacao = Guid.NewGuid();
            PagadorId = pagadorId;
            RecebedorId = recebedorId;
            Valor = valor;
        }
        public Guid IdentificacaoTransacao { get; private set; }
        public CarteiraEntity Pagador { get; private set; }
        public int PagadorId { get; private set; }
        public CarteiraEntity Recebedor { get; private set; }
        public int RecebedorId { get; private set; }
        public decimal Valor { get; private set; }
    }
}
