using System;
using System.Collections.Generic;
using System.Text;
using ApiContaVirtual.Data;

namespace ApiContaVirtualTest
{
    class ContaServiceFake
    {
        private readonly List<Conta> _conta;
        public ContaServiceFake()
        {
            _conta = new List<Conta>()
            {
                new Conta() { IdConta = 1, NomeCliente = "Ingrid", Saldo =0},
                new Conta() { IdConta = 1, NomeCliente = "Sandra", Saldo =0},
                new Conta() { IdConta = 1, NomeCliente = "Camila", Saldo =0},
            };
        }
        public IEnumerable<Conta> ListarContas()
        {
            return _conta;
        }
    }
}
