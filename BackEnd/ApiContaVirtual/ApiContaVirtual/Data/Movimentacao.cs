using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiContaVirtual.Data
{
    public class Movimentacao
    {
        /// <summary>
        /// Identificador da Movimentacao
        /// </summary>
        [Key]
        public int IdMovimentacao { get; set; }

        [JsonIgnore]
        public Conta Conta { get; set; }

        /// <summary>
        /// Identificador da Conta
        /// </summary>
        [Required]
        public int IdConta { get; set; }

        [JsonIgnore]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        /// <summary>
        /// Identificador do Tipo de Movimentacao
        /// </summary> 
        [Required]
        public int IdTipoMovimentacao { get; set; }

        /// <summary>
        /// Valor de movimentação
        /// </summary> 
        [Required, Column(TypeName = "DECIMAL(15,2)")]
        public decimal Valor { get; set; }

        /// <summary>
        /// Saldo atual da conta corrente antes da movimentacao
        /// </summary> 
        [Required, Column(TypeName = "DECIMAL(15,2)")]
        public decimal SaldoAnterior { get; set; }

        /// <summary>
        /// Saldo da conta corrente depois da movimentacao
        /// </summary> 
        [Required, Column(TypeName = "DECIMAL(15,2)")]
        public decimal SaldoPosterior { get; set; }


        /// <summary>
        /// Descricao da Movimentacao
        /// </summary>
        [Column(TypeName = "varchar(300)")]
        public string Descricao { get; set; }

        /// <summary>
        /// Data da Movimentacao
        /// </summary>
        [Required]
        public DateTime DataMovimentacao { get; set; }

    }
}
