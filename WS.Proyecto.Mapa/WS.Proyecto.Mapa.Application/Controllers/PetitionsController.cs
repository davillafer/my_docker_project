using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using WS.Proyecto.Mapa.Application.Model;
using WSClient.BoardGameWS;
using WSClient.UserWS;

namespace WS.Proyecto.Mapa.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetitionsController : ControllerBase
    {
        private IConfiguration _configuration; 
        public PetitionsController(IConfiguration configuration) 
        {
            this._configuration = configuration; 
        }

        // GET: api/Petitions
        [HttpGet]
        public ActionResult<IEnumerable<Petition>> GetPetitions()
        {
            // Get the client
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:DataEndPoint"));
            // Get the request
            var request = new RestRequest(Method.GET);
            // Set the format of the information
            request.RequestFormat = DataFormat.Json;
            // Get the response
            var response = client.Execute<List<Petition>>(request);
            // Check if it is not successful
            if (!response.IsSuccessful)
                return BadRequest();
            // Deserialize the content of the response into a list of games
            var model = JsonConvert.DeserializeObject<List<Petition>>(response.Content);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult<Petition> PostPetitions([FromBody] Petition petition)
        {
            // Get the client
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:DataEndPoint"));
            var postRequest = new RestRequest(Method.POST); 
            postRequest.RequestFormat = DataFormat.Json;
            postRequest.AddJsonBody(new { petition.Username, petition.BoardGame, petition.Latitude, petition.Longitude });
            if (!client.Execute(postRequest).IsSuccessful)
                return BadRequest();
            return Ok(petition);
        }

    }
}