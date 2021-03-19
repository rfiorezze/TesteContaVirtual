using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContaVirtual.Data
{
    public class Conta
    {
        /// <summary>
        /// Identificador do Conta
        /// </summary>
        [Key]
        public int IdConta { get; set; }

        /// <summary>
        /// Nome do Cliente da Conta
        /// </summary>
        [Required, Column(TypeName = "varchar(150)")]
        public string NomeCliente { get; set; }

        /// <summary>
        /// Saldo da Conta
        /// </summary>
        [Required, Column(TypeName = "DECIMAL(15,2)")]
        public decimal Saldo { get; set; }

    }
}
