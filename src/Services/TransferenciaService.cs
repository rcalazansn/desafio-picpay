using desafio.api.Core;
using desafio.api.DTOs;
using desafio.api.Enum;
using desafio.api.Models;
using desafio.api.Repositories.Interfaces;
using desafio.api.Requests;
using desafio.api.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace desafio.api.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ITransferenciaRepository _transacaoRepository;
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IAutorizadorService _autorizadorService;
        private readonly INotificacaoService _notificacaoService;

        public TransferenciaService
        (
            ITransferenciaRepository transacaoRepository, 
            ICarteiraRepository carteiraRepository,
            IAutorizadorService autorizadorService, 
            INotificacaoService notificacaoService
        )
        {
            _transacaoRepository = transacaoRepository;
            _carteiraRepository = carteiraRepository;
            _autorizadorService = autorizadorService;
            _notificacaoService = notificacaoService;
        }

        public async Task<Result<TransferenciaDto>> ExecuteAsync(TransferenciaRequest request)
        {
            if (!await _autorizadorService.AuthorizeAsync())
                return Result<TransferenciaDto>.Failure("Não Autorizado");

            var pagador = await _carteiraRepository.ObterPorId(request.SenderId);
            var recebedor = await _carteiraRepository.ObterPorId(request.ReciverId);

            if (pagador is null || recebedor is null)
                return Result<TransferenciaDto>.Failure("Nenhuma Carteira encontrada");

            if (pagador.SaldoConta < request.Valor || pagador.SaldoConta == 0)
                return Result<TransferenciaDto>.Failure("Saldo Insuficiente");

            if (pagador.TipoUsuario == TipoUsuario.Lojista)
                return Result<TransferenciaDto>.Failure($"Atenção, O lojista {pagador.NomeCompleto} não pode efetuar transferencia");

            pagador.DebitarSaldo(request.Valor);
            recebedor.CreditarSaldo(request.Valor);

            var transferencia = new TransferenciaEntity(pagador.Id, recebedor.Id, request.Valor);

            using (var transferenciaScope = await _transacaoRepository.BeginTransactionAsync())

            {
                try
                {
                    await ExecutarOperacoesEmParaleloAsync(pagador, recebedor, transferencia);
                    await CommitTransacaoAsync(transferenciaScope);
                }
                catch (Exception ex)
                {
                    await RollbackTransacaoAsync(transferenciaScope);
                    return Result<TransferenciaDto>.Failure("Erro ao realizar a transferência: " + ex.Message);
                }
            }

            await _notificacaoService.SendNotification();
            return Result<TransferenciaDto>.Success(transferencia.ToTransferenciaDto());
        }

        private async Task ExecutarOperacoesEmParaleloAsync
        (
            CarteiraEntity pagador, 
            CarteiraEntity recebedor,
            TransferenciaEntity transferencia
        )
        {
            var tarefas = new List<Task>
            {
                _carteiraRepository.AtualizarAsync(pagador),

                _carteiraRepository.AtualizarAsync(recebedor),

                _transacaoRepository.AdicionarTransaction(transferencia)
            };

            await Task.WhenAll(tarefas);
        }

        private async Task CommitTransacaoAsync(IDbContextTransaction transaction)
        {
            await _transacaoRepository.SalvarAsync();

            await transaction.CommitAsync();
        }

        private async Task RollbackTransacaoAsync(IDbContextTransaction transaction)
            => await transaction.RollbackAsync();
    }
}