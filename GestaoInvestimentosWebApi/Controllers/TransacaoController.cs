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
        private readonly ILogger<AtivoController> _logger;

        public TransacaoController(ITransacaoService transacaoService, ILogger<AtivoController> logger)
        {
            _transacaoService = transacaoService;
            _logger = logger;
        }

        /// <summary>
        /// Obtem transacao por id
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
                {
                    _logger.LogWarning("Não há transacao com o id informado!");
                    return BadRequest("Não há transacao com o id informado!");
                }

                return Ok(transacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(int? id, int? portfolioId, int? ativoId, int? tipoTransacao, int? quantidade, int? preco, string? dataTransacao)
        {
            try
            {
                return Ok(_transacaoService.GetAlTransacoesAsync(id, portfolioId, ativoId, tipoTransacao, quantidade, preco, dataTransacao));
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

        [HttpPut]
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
        public IActionResult Delete(int id)
        {
            try
            {
                _transacaoService.DeleteTransacaoAsync(id);
                return Ok("Transacao alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
