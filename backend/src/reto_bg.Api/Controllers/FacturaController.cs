using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Responses;
using reto_bg.Domain.Types;

namespace reto_bg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly ILogger<FacturaController> _logger;
        private readonly IFacturaRepository _contract;

        public FacturaController(ILogger<FacturaController> logger, IFacturaRepository contract)
        {
            _logger = logger;
            _contract = contract;
        }

        [HttpGet]
        public async Task<object> GetFacturas()
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - GetFacturas");
                ICollection<FacturaType> res = await _contract.GetFacturasAsync();
                if (res.Count < 0) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - GetFacturas");
            }
        }

        [HttpGet("{id}")]
        public async Task<object> GetFacturaPorID(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - GetFacturaPorID");
                FacturaResponsesType? res = await _contract.GetFacturaAsync(id);
                if (res is null) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - GetFacturaPorID");
            }
        }

        [HttpPost]
        public async Task<object> GuardarFactura(FacturaType factura)
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - GuardarFactura");
                bool res = await _contract.AddFacturaAsync(factura);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Falla al guardar los datos");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - GuardarFactura");
            }
        }

        [HttpPut]
        public async Task<object> ActualizarFactura(FacturaType factura)
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - ActualizarFactura");
                bool res = await _contract.UpdateFacturaAsync(factura);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Falla al guardar los datos");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - ActualizarFactura");
            }
        }

        [HttpDelete("{id}")]
        public async Task<object> DeleteFactura(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - DeleteFactura");
                bool res = await _contract.DeleteFacturaAsync(id);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Falla al guardar los datos");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - DeleteFactura");
            }
        }
    }
}
