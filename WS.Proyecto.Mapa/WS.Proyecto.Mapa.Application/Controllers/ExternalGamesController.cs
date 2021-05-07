using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using WS.Proyecto.Mapa.Application.Model;

namespace WS.Proyecto.Mapa.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalGamesController : ControllerBase
    {
        private IConfiguration _configuration;
        private const string Key = "GMNTjE6ld3";
        private const string BaseUrl = "https://www.boardgameatlas.com/api";
        private const string Extra = "&pretty=true&client_id=";

        public ExternalGamesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: api/Games
        [HttpGet]
        public ActionResult<List<ExternalGame>> GetExternalBoardGames()
        {
            // Get the client
            var client = new RestClient($"{BaseUrl}/search?order_by=popularity{Extra}{Key}");
            // Get the request
            var request = new RestRequest(Method.GET);
            // Set the format of the information
            request.RequestFormat = DataFormat.Json;
            // Get the response
            var response = client.Execute<List<String>>(request);
            // Check if it is not successful
            if (!response.IsSuccessful)
                return BadRequest();
            // Deserialize the content of the response into a list of games
            var googleSearch = JObject.Parse(response.Content);
            // get JSON result objects into a list
            var results = googleSearch["games"].Children().ToList();
            List<ExternalGame> externalGamesList = new List<ExternalGame>();
            foreach (var game in results)
            {
                JObject jObject = JObject.Parse(game.ToString());
                ExternalGame eg = new ExternalGame(jObject);
                externalGamesList.Add(eg);
            }
            return Ok(externalGamesList);
        }

        // GET: api/Games/afsdWRE
        [HttpGet("{id}")]
        public ActionResult<List<ExternalGame>> GetExternalBoardGames([FromRoute] string id)
        {
            // Get the client
            var client = new RestClient($"{BaseUrl}/search?ids={id}{Extra}{Key}");
            // Get the request
            var request = new RestRequest(Method.GET);
            // Set the format of the information
            request.RequestFormat = DataFormat.Json;
            // Get the response
            var response = client.Execute<List<String>>(request);
            // Check if it is not successful
            if (!response.IsSuccessful)
            {
                client = new RestClient($"{BaseUrl}/search?name={id}{Extra}{Key}");
                // Get the request
                request = new RestRequest(Method.GET);
                // Set the format of the information
                request.RequestFormat = DataFormat.Json;
                // Get the response
                response = client.Execute<List<String>>(request);
                if (!response.IsSuccessful)
                    return BadRequest();
            }
            // Deserialize the content of the response into a list of games
            var googleSearch = JObject.Parse(response.Content);
            // get JSON result objects into a list
            var results = googleSearch["games"].Children().ToList();
            List<ExternalGame> externalGamesList = new List<ExternalGame>();
            foreach (var game in results)
            {
                JObject jObject = JObject.Parse(game.ToString());
                ExternalGame eg = new ExternalGame(jObject);
                externalGamesList.Add(eg);
            }
            return Ok(externalGamesList);
        }
    }
}