using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiContaVirtual.Data;
using ApiContaVirtual.Retornos;
using ApiContaVirtual.Models;

namespace ApiContaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacoesController : ControllerBase
    {
        private readonly BaseContext _context;

        public MovimentacoesController(BaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar Extrato
        /// </summary>
        /// <remarks>
        /// Este método lista o extrato de uma determinada conta virtual
        /// - Por período
        /// - Por tipo de transação | Ex: 1- Crédito ou 2- débito
        /// Exemplo: 1- Crédito | 2- Débito
        /// </remarks>
        /// <returns>Este método retorna os dados de todas as movimentações realizadas em um determinado período.</returns>
        /// <response code="400">Retorno caso ocorra algum erro</response>
        [HttpGet("{idConta}/{TipoMovimentacao}/{DataInicio}/{DataFim}")]
        public ActionResult ListarExtrato(int idConta, int TipoMovimentacao, string DataInicio, string DataFim)
        {
            //Inicializando variáveis
            decimal saldoInicial = 0;
            decimal saldoFinal = 0;
            EstruturaRetornoListarExtrato retornoExtrato = new EstruturaRetornoListarExtrato();

            if (string.IsNullOrEmpty(DataInicio) || string.IsNullOrEmpty(DataFim))
            {
                retornoExtrato.IndicadorRetorno = -1;
                retornoExtrato.DescricaoRetorno = "Favor preencher os campos de Data Inicio e Data Fim!";
                return NotFound(retornoExtrato);
            }

            try
            {
                //Conversão de string para DateTime
                DateTime DataInicial = Convert.ToDateTime(DataInicio);
                DateTime DataFinal = Convert.ToDateTime(DataFim);

                //Setando a data para o final do dia
                DataFinal = DataFinal.AddHours(23).AddMinutes(59).AddSeconds(59);

                //Consulta LINQ
                var query =
                        from m in _context.Movimentacao
                        where m.IdConta == idConta && m.DataMovimentacao >= DataInicial &&
                        m.DataMovimentacao <= DataFinal
                        select new { Movimentacao = m };


                // Caso deseje filtrar por crédito ou debito
                if (TipoMovimentacao != 0)
                    query = query.Where(t => t.Movimentacao.IdTipoMovimentacao == TipoMovimentacao);

                var retorno = query.ToList();

                //Verifica se a query retornou registros
                if (retorno.Count > 0)
                {
                    saldoInicial = retorno[0].Movimentacao.SaldoAnterior;
                    saldoFinal = retorno[retorno.Count - 1].Movimentacao.SaldoPosterior;
                    
                    List<MovimentacaoConta> movimentacoesFiltradas = new List<MovimentacaoConta>();

                    //Preenchendo a lista de acordo com o resultado da query LINQ
                    foreach (var item in retorno)
                    {
                        MovimentacaoConta movimentacao = new MovimentacaoConta();
                        movimentacao.IdMovimentacao = item.Movimentacao.IdMovimentacao;
                        movimentacao.IdConta = item.Movimentacao.IdConta;
                        movimentacao.Descricao = item.Movimentacao.Descricao;
                        movimentacao.TipoMovimentacao.IdTipoMovimentacao = item.Movimentacao.IdTipoMovimentacao;
                        movimentacao.TipoMovimentacao.Descricao = _context.TipoMovimentacao.Find(item.Movimentacao.IdTipoMovimentacao).Descricao;
                        movimentacao.Valor = string.Format("{0:0,0.00}", item.Movimentacao.Valor);
                        movimentacao.SaldoAnterior = string.Format("{0:0,0.00}", item.Movimentacao.SaldoAnterior);
                        movimentacao.SaldoPosterior = string.Format("{0:0,0.00}", item.Movimentacao.SaldoPosterior);
                        movimentacao.DataMovimentacao = item.Movimentacao.DataMovimentacao.ToString("dd/MM/yyyy HH:mm");
                        movimentacoesFiltradas.Add(movimentacao);
                    }
                        

                    // Preparando estrutura de retorno com sucesso
                    retornoExtrato.SaldoInicial = string.Format("{0:0,0.00}", saldoInicial);
                    retornoExtrato.SaldoFinal = string.Format("{0:0,0.00}", saldoFinal);
                    retornoExtrato.Movimentacoes = movimentacoesFiltradas;
                }
                else
                    retornoExtrato.DescricaoRetorno = "Não há registros no extrato";

            }
            catch (Exception ex)
            {
                retornoExtrato.IndicadorRetorno = -1;
                retornoExtrato.DescricaoRetorno = ex.Message;
            }            

            return Ok(retornoExtrato);
        }

        /// <summary>
        /// Incluir Movimentação
        /// </summary>
        /// <remarks>
        /// Inclui Movimentação na conta virtual 
        /// Exemplo: 1- Crédito | 2- Débito
        /// Sample request:
        ///
        ///     POST / Movimentacao
        ///     {
        ///        "idConta": 1,
        ///        "idTipoMovimentacao": 1,
        ///        "valor": 2000,
        ///        "descricao": "Salário mês de março",
        ///        "dataMovimentacao": "2021-03-18"
        ///     }
        ///
        /// </remarks>
        /// <returns>Este método retorna os dados de movimentação na conta que foram incluídos</returns>
        /// <response code="400">Retorno caso ocorra algum erro</response>
        [HttpPost]
        public ActionResult IncluirMovimentacao(Movimentacao movimentacao)
        {
            try
            {
                decimal SaldoContaCorrente = _context.Conta.Find(movimentacao.IdConta).Saldo;
                decimal SaldoAnterior = SaldoContaCorrente;
                decimal SaldoPosterior = 0;

                //Verificando se é credito ou débito
                if (movimentacao.IdTipoMovimentacao == 1)
                    SaldoPosterior = SaldoAnterior + movimentacao.Valor;

                if (movimentacao.IdTipoMovimentacao == 2)
                    SaldoPosterior = SaldoAnterior - movimentacao.Valor;


                //Carregando o valor de Saldo Anterior e Posterior
                movimentacao.SaldoAnterior = SaldoAnterior;
                movimentacao.SaldoPosterior = SaldoPosterior;

                //Atualizando saldo da conta
                _context.Conta.Find(movimentacao.IdConta).Saldo = SaldoPosterior;

                _context.Movimentacao.Add(movimentacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(movimentacao);
        }

    }
}
