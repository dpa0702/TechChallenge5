using GestaoInvestimentosCore.DTO.Portfolio;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInvestimentosWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        private readonly ILogger<PortfolioController> _logger;

        public PortfolioController(IPortfolioService portfolioService, ILogger<PortfolioController> logger)
        {
            _portfolioService = portfolioService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém portfólio por id
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
                Portfolio portfolio = _portfolioService.GetPortfolioByIdAsync(id);
                if (portfolio == null)
                {
                    _logger.LogWarning("Não há portfolio com o id informado!");
                    return BadRequest("Não há portfolio com o id informado!");
                }

                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtém todos portfólios
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo:
        /// 
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        [HttpGet]
        public IActionResult GetAll(int? id, int? usuarioId, string? nome, string? descricao)
        {
            try
            {
                return Ok(_portfolioService.GetAllPortfoliosAsync(id, usuarioId, nome, descricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria um Portfólio
        /// </summary>
        /// <param name="createPortfolioDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo:
        /// 
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        [HttpPost]
        public IActionResult Create(CreatePortfolioDTO createPortfolioDTO)
        {
            try
            {
                _portfolioService.AddPortfolioAsync(createPortfolioDTO);
                return Ok("Portfolio criado com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um Portfólio
        /// </summary>
        /// <param name="updatePortfolioDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo:
        /// 
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        [HttpPut]
        public IActionResult Update(UpdatePortfolioDTO updatePortfolioDTO)
        {
            try
            {
                _portfolioService.UpdatePortfolioAsync(updatePortfolioDTO);
                return Ok("Portfolio alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um Portfólio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo:
        /// 
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _portfolioService.DeletePortfolioAsync(id);
                return Ok("Portfolio alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
