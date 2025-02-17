using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reto_bg.Application.Contracts;
using reto_bg.Domain.Types;

namespace reto_bg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoRepository _contract;

        public ProductoController(ILogger<ProductoController> logger, IProductoRepository contract)
        {
            _logger = logger;
            _contract = contract;
        }

        [HttpGet("{id}")]
        public async Task<object> getProductoID(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - getProductoID");
                ProductoType? type = await _contract.GetProductoAsync(id);
                if (type is null) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, type);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - getProductoID");
            }
        }

        [HttpGet]
        public async Task<object> getProductos()
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - getProductos");
                ICollection<ProductoType> type = await _contract.GetProductosAsync();
                if (type.Count < 0) return StatusCode(StatusCodes.Status404NotFound, "Sin resultados previos");
                return StatusCode(StatusCodes.Status200OK, type);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - getProductos");
            }
        }

        [HttpPost]
        public async Task<object> AddProducto(ProductoType producto)
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - AddProducto");
                bool type = await _contract.AddProductoAsync(producto);
                if (type is false) return StatusCode(StatusCodes.Status400BadRequest, "No se pudo guardar el producto");
                return StatusCode(StatusCodes.Status200OK, type);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - AddProducto");
            }
        }

        [HttpPut]
        public async Task<object> UpdateProducto(ProductoType producto)
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - UpdateProducto");
                bool type = await _contract.UpdateProductoAsync(producto);
                if (type is false) return StatusCode(StatusCodes.Status400BadRequest, "No se pudo actualizar el producto");
                return StatusCode(StatusCodes.Status200OK, type);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - UpdateProducto");
            }
        }

        [HttpDelete]
        public async Task<object> DeleteProducto(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo Controller - DeleteProducto");
                bool type = await _contract.DeleteProductoAsync(id);
                if (type is false) return StatusCode(StatusCodes.Status400BadRequest, "No se pudo eliminar el producto");
                return StatusCode(StatusCodes.Status200OK, type);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Finaliza metodo Controller - DeleteProducto");
            }
        }
    }
}
