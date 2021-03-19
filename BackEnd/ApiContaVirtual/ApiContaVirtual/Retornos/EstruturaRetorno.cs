using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContaVirtual.Retornos
{
    public class EstruturaRetorno
    {
        public EstruturaRetorno()
        {
            IndicadorRetorno = 0;
            DescricaoRetorno = "";
        }

        public int IndicadorRetorno { get; set; }
        public string DescricaoRetorno { get; set; }
    }
}
