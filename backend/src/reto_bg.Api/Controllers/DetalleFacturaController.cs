using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Types;

namespace reto_bg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController : ControllerBase
    {
        private readonly ILogger<DetalleFacturaController> _logger;
        private readonly IDetalleFacturaRepository _contract;

        public DetalleFacturaController(ILogger<DetalleFacturaController> logger, IDetalleFacturaRepository contract)
        {
            _contract = contract;
            _logger = logger;
        }

        [HttpGet]
        public async Task<object> getDetalles()
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller - GetDetalles");
                ICollection<DetalleFacturaType>? detalles = await _contract.GetDetallesFacturaAsync();
                if (detalles.Count < 0) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, detalles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo controller - GetDetalles");
            }
        }

        [HttpGet("{id}")]
        public async Task<object> getDetalle(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller - getDetalle");
                DetalleFacturaType? detalle = await _contract.GetDetalleFacturaAsync(id);
                if (detalle is null) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, detalle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo controller - getDetalle");
            }
        }


        [HttpPost]
        public async Task<object> SaveDetalle(DetalleFacturaType detalle)
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller - SaveDetalle");
                bool res = await _contract.AddDetalleFacturaAsync(detalle);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo controller - SaveDetalle");
            }
        }

        [HttpPut]
        public async Task<object> UpdateDetalle(DetalleFacturaType detalle)
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller - UpdateDetalle");
                bool res = await _contract.UpdateDetalleFacturaAsync(detalle);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo controller - UpdateDetalle");
            }
        }

        [HttpDelete("{id}")]
        public async Task<object> DeleteDetalle(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller - DeleteDetalle");
                bool res = await _contract.DeleteDetalleFacturaAsync(id);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo controller - DeleteDetalle");
            }
        }
    }
}
