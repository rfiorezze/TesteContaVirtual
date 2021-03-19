using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiContaVirtual.Data;

namespace ApiContaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimentacaosController : ControllerBase
    {
        private readonly BaseContext _context;

        public TipoMovimentacaosController(BaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar Tipo Movimentação
        /// </summary>
        /// <remarks>
        /// Este método lista os tipos de movimentação
        /// Exemplo: 1- Crédito | 2- Débito
        /// </remarks>
        /// <returns>Este método retorna os tipos de movimentação cadastrados.</returns>
        /// <response code="400">Retorno caso ocorra algum erro</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMovimentacao>>> GetTipoMovimentacao()
        {
            return await _context.TipoMovimentacao.ToListAsync();
        }

    }
}
