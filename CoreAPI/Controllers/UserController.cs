using CoreAPI.Model;
using CoreAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLoginHandlerRepository<UserCredentialsDto> _userLoginRepository;
        private readonly IConfiguration _configuration;

        public UserController(IUserLoginHandlerRepository<UserCredentialsDto> userLoginRepository, IConfiguration configuration)
        {
            _userLoginRepository = userLoginRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult UserLogin([FromBody]UserCredentialsDto userLogin)
        {
            var token = _userLoginRepository.GetToken(userLogin, _configuration);
            if(token == null) { return BadRequest(string.Empty); }
            return Ok(token);
        }
    }
}
