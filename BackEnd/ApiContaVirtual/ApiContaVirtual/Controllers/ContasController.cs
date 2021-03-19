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
    public class ContasController : ControllerBase
    {
        private readonly BaseContext _context;

        public ContasController(BaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar Conta Virtual
        /// </summary>
        /// <remarks>
        /// Lista dados da conta virtual do cliente
        /// </remarks>
        /// <returns>Este método retorna dados de uma conta virtual de um cliente específico</returns>
        /// <response code="400">Retorno caso ocorra algum erro</response>     
        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetConta(int id)
        {
            var conta = await _context.Conta.FindAsync(id);

            if (conta == null)
            {
                return NotFound();
            }

            return conta;
        }

        /// <summary>
        /// Listar Contas Virtuais
        /// </summary>
        /// <remarks>
        /// Lista dados das contas virtuais dos clientes
        /// </remarks>
        /// <returns>Este método retorna dados de contas virtuais</returns>
        /// <response code="400">Retorno caso ocorra algum erro</response>   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conta>>> GetConta()
        {
            return await _context.Conta.ToListAsync();
        }


        /// <summary>
        /// Incluir Conta Virtual
        /// </summary>
        /// <remarks>
        /// Inclui conta virtual no banco de dados
        /// Sample request:
        ///
        ///     POST / Conta
        ///     {
        ///        "nomeCliente": "Renato",
        ///        "saldo": 0
        ///     }
        ///
        /// </remarks>
        /// <returns>Este método retorna o identiicador da conta criado</returns>
        /// <response code="400">Retorno caso ocorra algum erro</response>            
        [HttpPost]
        public async Task<ActionResult<Conta>> PostConta(Conta conta)
        {
            try
            {
                _context.Conta.Add(conta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(conta);
        }

    }
}
