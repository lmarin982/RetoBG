using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Types;

namespace reto_bg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepository _contract;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository contract)
        {
            _logger = logger;
            _contract = contract;
        }

        [HttpPost("auth")]
        public async Task<object> Autenticacion(AuthType auth)
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - Autenticacion");
                if (string.IsNullOrEmpty(auth.Usuario) || string.IsNullOrEmpty(auth.Contrasenia)) return StatusCode(StatusCodes.Status404NotFound, "Usuario no encontrado, vuelva a intentar");
                UsuarioType? res = await _contract.GetUsuarioAsync(auth.Usuario, auth.Contrasenia);
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - Autenticacion");
            }
        }
    }
}


public class AuthType
{
    public string? Usuario { get; set; }
    public string? Contrasenia { get; set; }
}