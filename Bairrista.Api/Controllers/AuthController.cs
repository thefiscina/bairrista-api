using Bairrista.Dominio.Service;
using Bairrista.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _service;

        public AuthController(ILogger<AuthController> logger, IAuthService service)
        {
            _logger = logger;
            _service = service;
        }        

        [HttpPost]
        public AuthResponse Salvar([FromBody] AuthRequest request)
        {
            return _service.Login(request);
        }

        [HttpPost("SocialLogin")]
        public AuthResponse SalvarSocial([FromBody] AuthRequest request)
        {
            return _service.LoginSocial(request);
        }
    }
}