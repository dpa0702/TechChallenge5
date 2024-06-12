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
