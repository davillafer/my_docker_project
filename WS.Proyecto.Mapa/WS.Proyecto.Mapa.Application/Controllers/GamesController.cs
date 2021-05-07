using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using WS.Proyecto.Mapa.Application.Model;
using WSClient.BoardGameWS;
using WSClient.UserWS;

namespace WS.Proyecto.Mapa.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IConfiguration _configuration; 
        public GamesController(IConfiguration configuration) 
        {
            this._configuration = configuration; 
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetBoardGames()
        {
            BoardGameWSClient boardGameClient = new BoardGameWSClient(BoardGameWSClient.EndpointConfiguration.BoardGameWSPort, _configuration.GetValue<string>("ApplicationSettings:BoardGameEndPoint"));
            var result = await boardGameClient.readAllAsync();
            if (result == null)
                return NotFound();
            return Ok(result.@return);
        }

    }
}