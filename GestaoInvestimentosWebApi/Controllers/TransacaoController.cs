using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using GestaoInvestimentosCore.DTO.Transacao;

namespace GestaoInvestimentosWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        /// <summary>
        /// Obtem livro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo:
        /// 
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Transacao transacao = _transacaoService.GetTransacaoByIdAsync(id);
                if (transacao == null)
                    return BadRequest("Não há transacao com o id informado!");

                return Ok(transacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_transacaoService.GetAlTransacoesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateTransacaoDTO createTransacaoDTO)
        {
            try
            {
                _transacaoService.AddTransacaoAsync(createTransacaoDTO);
                return Ok("Transacao criada com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(UpdateTransacaoDTO updateTransacaoDTO)
        {
            try
            {
                _transacaoService.UpdateTransacaoAsync(updateTransacaoDTO);
                return Ok("Transacao alterada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Transacao transacao)
        {
            try
            {
                _transacaoService.DeleteTransacaoAsync(transacao);
                return Ok("Transacao alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
