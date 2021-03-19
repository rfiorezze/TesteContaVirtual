using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContaVirtual.Data
{
    public class TipoMovimentacao
    {
        /// <summary>
        /// Identificador do Conta
        /// </summary>
        [Key]
        public int IdTipoMovimentacao { get; set; }

        /// <summary>
        /// Descricao do Tipo de Movimentacao
        /// </summary>
        [Required, Column(TypeName = "varchar(300)")]
        public string Descricao { get; set; }
    }
}
