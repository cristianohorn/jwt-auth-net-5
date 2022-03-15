using System.Threading.Tasks;
using AuthHorn.Models;
using AuthHorn.Repositories;
using AuthHorn.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthHorn.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Usuário não encontrado." });
            }
            var token = TokenService.GenerateToken(user);

            user.Password = "";
            return new { user = user, token = token };
        }
    }
}