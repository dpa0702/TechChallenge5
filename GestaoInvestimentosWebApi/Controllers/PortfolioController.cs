
using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.DTO.Portfolio;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInvestimentosWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Portfolio portfolio = _portfolioService.GetPortfolioByIdAsync(id);
                if (portfolio == null)
                    return BadRequest("Não há portfolio com o id informado!");

                return Ok(portfolio);
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
                return Ok(_portfolioService.GetAllPortfoliosAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePortfolioDTO createPortfolioDTO)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdatePortfolioDTO updatePortfolioDTO)
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
        public async Task<IActionResult> Delete(Portfolio portfolio)
        {
            try
            {
                _portfolioService.DeletePortfolioAsync(portfolio);
                return Ok("Portfolio alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
