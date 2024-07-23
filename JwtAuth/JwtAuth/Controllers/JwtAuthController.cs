using JwtAuth.Models.RequestModels;
using JwtAuth.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth.Controllers
{
    public class JwtAuthController : BaseController
    {
        private readonly IJwtAuthService _jwtAuthService;

        public JwtAuthController(IJwtAuthService jwtAuthService)
        {
            _jwtAuthService = jwtAuthService;
        }

        /// <summary>
        /// Endpoint for registration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequestModel model)
        {
            try
            {
                var user = await _jwtAuthService.Register(model);
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint for login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserRequestModel model)
        {
            try
            {
                var token = await _jwtAuthService.Login(model);
                return Ok(new { token });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

}
