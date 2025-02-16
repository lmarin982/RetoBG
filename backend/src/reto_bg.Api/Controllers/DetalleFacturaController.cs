using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reto_bg.Application.Contracts;

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
    }
}
