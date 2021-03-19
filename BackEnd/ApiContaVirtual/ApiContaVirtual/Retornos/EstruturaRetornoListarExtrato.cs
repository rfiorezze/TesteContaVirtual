using ApiContaVirtual.Data;
using ApiContaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContaVirtual.Retornos
{
    public class EstruturaRetornoListarExtrato : EstruturaRetorno
    {
        public string SaldoInicial { get; set; }
        public List<MovimentacaoConta> Movimentacoes { get; set; }
        public string SaldoFinal { get; set; }

    }
}
