using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reto_bg.Application.Contracts;

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
    }
}
