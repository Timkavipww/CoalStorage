//using Microsoft.AspNetCore.Mvc;
//using CoalStorage.Core.Interfaces;
//using CoalStorage.Core.Common;

//namespace CoalStorage.API.Controllers
//{
//    [Route("api/auth")]
//    public class AuthController : ControllerBase
//    {
//        private readonly ITokenService _tokenService;

//        public AuthController(ITokenService tokenService)
//        {
//            _tokenService = tokenService;
//        }

//        // POST api/auth/login
//        [HttpPost("login")]
//        public IActionResult Login([FromBody] LoginModel model)
//        {
//            // Генерация токена с использованием введенных данных
//            var token = _tokenService.GenerateToken(model.Username, model.Password);
//            if (token == null)
//            {
//                return Unauthorized("Invalid credentials");
//            }

//            return Ok(new { Token = token });
//        }
//    }
//}
