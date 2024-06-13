using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInvestimentosWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioService usuarioService, ILogger<UsuarioController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém usuário por id
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
                Usuario usuario = _usuarioService.GetUsuarioByIdAsync(id);
                if (usuario == null)
                {
                    _logger.LogWarning("Não há usuario com o id informado!");
                    return BadRequest("Não há usuario com o id informado!");
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtém todos usuários
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo:
        /// 
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        [HttpGet]
        public IActionResult GetAll(int? id, string? nome, string? email, string? senha)
        {
            try
            {
                return Ok(_usuarioService.GetAllUsuariosAsync(id, nome, email, senha));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria um Usuário
        /// </summary>
        /// <param name="createUsuarioDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo:
        /// 
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        [HttpPost]
        public IActionResult Create(CreateUsuarioDTO createUsuarioDTO)
        {
            try
            {
                _usuarioService.AddUsuarioAsync(createUsuarioDTO);
                return Ok("Usuario criado com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um Usuário
        /// </summary>
        /// <param name="updateUsuarioDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo:
        /// 
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        [HttpPut]
        public IActionResult Update(UpdateUsuarioDTO updateUsuarioDTO)
        {
            try
            {
                _usuarioService.UpdateUsuarioAsync(updateUsuarioDTO);
                return Ok("Usuario alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um Usuário
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
                _usuarioService.DeleteUsuarioAsync(id);
                return Ok("Usuario alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginUsuarioDTO loginUsuarioDTO)
        {
            try
            {
                LoginUsuarioDTO usuarioLogin = _usuarioService.Login(loginUsuarioDTO);
                if (usuarioLogin == null)
                {
                    _logger.LogWarning("Usuário ou senha inválidos!");
                    return NotFound(new { message = "Usuário ou senha inválidos!" });
                }

                return Ok(usuarioLogin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Forget")]
        public IActionResult Forget()
        {
            try
            {
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}