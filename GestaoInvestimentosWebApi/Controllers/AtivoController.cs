
using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInvestimentosWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtivoController : ControllerBase
    {
        private readonly IAtivoService _ativoService;
        private readonly ILogger<AtivoController> _logger;

        public AtivoController(IAtivoService ativoService, ILogger<AtivoController> logger)
        {
            _ativoService = ativoService;
            _logger = logger;
        }

        /// <summary>
        /// Obtem ativo por id
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
                Ativo ativo = _ativoService.GetAtivoByIdAsync(id);
                if (ativo == null) {
                    _logger.LogWarning("Não há ativo com o id informado!");
                    return BadRequest("Não há ativo com o id informado!");
                }

                return Ok(ativo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(int? id, int? tipoAtivo, string? nome, string? codigo)
        {
            try
            {
                if (_ativoService.TipoAtivoIsValid(tipoAtivo))
                {
                    return Ok(_ativoService.GetAllAtivosAsync(id, tipoAtivo, nome, codigo));
                }
                else
                {
                    _logger.LogWarning("O TipoAtivo é inválido!");
                    return BadRequest("O TipoAtivo é inválido!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateAtivoDTO createAtivoDTO)
        {
            try
            {
                _ativoService.AddAtivoAsync(createAtivoDTO);
                return Ok("Ativo criado com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(UpdateAtivoDTO updateAtivoDTO)
        {
            try
            {
                _ativoService.UpdateAtivoAsync(updateAtivoDTO);
                return Ok("Ativo alterado com sucesso!");
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
                _ativoService.DeleteAtivoAsync(id);
                return Ok("Ativo alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
