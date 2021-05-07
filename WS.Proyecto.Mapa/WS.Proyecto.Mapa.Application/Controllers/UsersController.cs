using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WS.Proyecto.Mapa.Application.Model;
using WSClient.UserWS;

namespace WS.Proyecto.Mapa.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByUsernamePassword([FromQuery] string username, [FromQuery] string password)
        {
            UserWSClient boardGameClient = new UserWSClient(UserWSClient.EndpointConfiguration.UserWSPort, _configuration.GetValue<string>("ApplicationSettings:UserEndPoint"));
            var result = await boardGameClient.findByUsernamePasswordAsync(username, password);
            if (result == null)
                return NotFound();
            if (result.@return == null)
                return Ok(new List<User>());
            return Ok(result.@return);
        }
    }
}