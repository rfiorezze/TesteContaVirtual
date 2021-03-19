using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiContaVirtual.Data;

namespace ApiContaVirtual.Models
{


    public class MovimentacaoConta
    {

        public MovimentacaoConta()
        {
            TipoMovimentacao = new TipoMovimentacao();
        }

        /// <summary>
        /// Identificador da Movimentacao
        /// </summary>
        public int IdMovimentacao { get; set; }

        /// <summary>
        /// Identificador da Conta
        /// </summary>
        public int IdConta { get; set; }

        /// <summary>
        /// Identificador do Tipo de Movimentacao
        /// </summary> 
        public TipoMovimentacao TipoMovimentacao { get; set; }

        /// <summary>
        /// Valor de movimentação
        /// </summary> 
        public string Valor { get; set; }

        /// <summary>
        /// Saldo atual da conta corrente antes da movimentacao
        /// </summary> 
        public string SaldoAnterior { get; set; }

        /// <summary>
        /// Saldo da conta corrente depois da movimentacao
        /// </summary> 
        public string SaldoPosterior { get; set; }

        /// <summary>
        /// Descricao da Movimentacao
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data da Movimentacao
        /// </summary>
        public string DataMovimentacao { get; set; }
    }
}
