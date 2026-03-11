using Microsoft.AspNetCore.Mvc;
using Models;
using Query.Interfaces;

namespace MiPrimeraApi.Controllers
{
    /// <summary>
    /// Controlado para los usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioQueries _usuarioQueries;

        /// <summary>
        /// UsuarioController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="usuarioQueries"></param>
        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioQueries usuarioQueries)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _usuarioQueries = usuarioQueries ?? throw new ArgumentNullException(nameof(usuarioQueries));
        }

        /// <summary>
        /// Lista todos los usuarios
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ListarUsuarios()
        {
            _logger.LogInformation("Iniciando listado de todos los usuarios");
            var rs = await _usuarioQueries.GetAll();
            _logger.LogError("Error  ocurrido");
            return Ok(rs);
        }

        /// <summary>
        /// Busca un usuario por id y nombre
        /// </summary>
        /// <param name="id">Id del usuario</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UsuarioId(int id)
        {
            try
            {
                var us = await _usuarioQueries.GetById(id);
                if(us == null)
                    return NotFound();

                return Ok(us);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Texto cristian del error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
