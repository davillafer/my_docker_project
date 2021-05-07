using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using WS.Proyecto.Mapa.Web.Model;
using WS.Proyecto.Mapa.Web.Models;

namespace WS.Proyecto.Mapa.Web.Controllers
{
    public class PetitionsController : Controller
    {
        private IConfiguration _configuration;
        public PetitionsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Get the client
            var client = new RestClient(_configuration.GetValue<string>("WebSettings:PetitionsEndPoint"));
            // Get the request
            var request = new RestRequest(Method.GET);
            // Set the format of the information
            request.RequestFormat = DataFormat.Json;
            // Get the response
            var response = client.Execute<List<String>>(request);
            // Check if it is not successful
            if (!response.IsSuccessful)
                return BadRequest();
            // Deserialize the content of the response into a list of petitions
            var model = JsonConvert.DeserializeObject<List<Petition>>(response.Content);
            List<Coordinates> aux = new List<Coordinates>();
            foreach( Petition p in model)
            {
                aux.Add(new Coordinates(p.Latitude, p.Longitude));
            }
            ViewBag.isValidUser = true;
            ViewBag.coordinates = aux;
            ViewBag.Success = false;
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] Petition petition)
        {
            // Get the client
            var clientPetitions = new RestClient(_configuration.GetValue<string>("WebSettings:PetitionsEndPoint"));
            // ------ Check the credentials of the user ----
            bool isValidUser = IsValid(petition.Username, petition.Password);
            // ------ Store new Value ----
            if (isValidUser)
            {
                var postRequest = new RestRequest(Method.POST);
                postRequest.RequestFormat = DataFormat.Json;
                postRequest.AddJsonBody(new { petition.Username, petition.BoardGame, petition.Latitude, petition.Longitude });
                // Get the response
                var postResponse = clientPetitions.Execute(postRequest);
                if (!postResponse.IsSuccessful)
                    return BadRequest();
                ViewBag.Success = true;
            } 
            else
            {   
                ViewBag.Success = false;
            }
            // ------ Get default Values ----
            // Get the request
            var request = new RestRequest(Method.GET);
            // Set the format of the information
            request.RequestFormat = DataFormat.Json;
            // Get the response
            var response = clientPetitions.Execute<List<String>>(request);
            // Check if it is not successful
            if (!response.IsSuccessful)
                return BadRequest();
            // Deserialize the content of the response into a list of petitions
            var model = JsonConvert.DeserializeObject<List<Petition>>(response.Content);
            List<Coordinates> aux = new List<Coordinates>();
            foreach (Petition p in model)
            {
                aux.Add(new Coordinates(p.Latitude, p.Longitude));
            }
            ViewBag.isValidUser = isValidUser;
            ViewBag.coordinates = aux;
            return View();
        }

        private bool IsValid(string username, string password)
        {
            var client = new RestClient(_configuration.GetValue<string>("WebSettings:UsersEndPoint"));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            var response = client.Execute<List<String>>(request);
            var model = JsonConvert.DeserializeObject<List<User>>(response.Content);
            return model.Count != 0;
        }
    }
}