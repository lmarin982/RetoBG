using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Types;

namespace reto_bg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _contract;

        public ClienteController(ILogger<ClienteController> logger, IClienteRepository contract)
        {
            _logger = logger;
            _contract = contract;
        }

        [HttpGet]
        public async Task<object> GetClientes()
        {
            try
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
                ICollection<ClienteType> clientes = await _contract.GetClientesAsync();
                if (clientes.Count < 0) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, clientes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
            }
        }

        [HttpGet("{id}")]
        public async Task<object> GetCliente(int id)
        {
            try
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
                ClienteType? cliente = await _contract.GetClienteAsync(id);
                if (cliente is null) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
            }
        }

        [HttpPost]
        public async Task<object> SaveCliente(ClienteType cliente)
        {
            try
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
                bool res = await _contract.AddClienteAsync(cliente);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "No se pudo guardar la data");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
            }
        }

        [HttpPut]
        public async Task<object> UpdateCliente(ClienteType cliente)
        {
            try
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
                bool res = await _contract.UpdateClienteAsync(cliente);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "No se pudo actualizar la data");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
            }
        }

        [HttpDelete("{id}")]
        public async Task<object> DeleteCliente(int id)
        {
            try
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
                bool res = await _contract.DeleteClienteAsync(id);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "No se pudo Eliminar el cliente");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - GetClientes");
            }
        }
    }
}
