using desafio.api.Core;
using desafio.api.Enum;

namespace desafio.api.Models
{
    public class CarteiraEntity : BaseEntity
    {
        public CarteiraEntity
        (
            string nomeCompleto, 
            string cpfcnpj, 
            string email, 
            string senha,
            TipoUsuario tipoUsuario, 
            decimal saldoConta = 0)
        {
            NomeCompleto = nomeCompleto;
            CpfCnpj = cpfcnpj;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            SaldoConta = saldoConta;
        }

        public string NomeCompleto { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public decimal SaldoConta { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }

        public void DebitarSaldo(decimal valor)
            => SaldoConta -= valor;

        public void CreditarSaldo(decimal valor)
            => SaldoConta += valor;
    }
}
