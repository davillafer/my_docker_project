using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using WS.Proyecto.Mapa.Application.Model;
using WS.Proyecto.Mapa.Web.Model;
using WS.Proyecto.Mapa.Web.Models;

namespace WS.Proyecto.Mapa.Web.Controllers
{
    public class GamesController : Controller
    {
        private IConfiguration _configuration;
        public GamesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IActionResult Index()
        {
            // Get the client
            var client = new RestClient(_configuration.GetValue<string>("WebSettings:MyExternalGamesEndPoint"));
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
            var model = JsonConvert.DeserializeObject<List<ExternalGame>>(response.Content);
            // Order the list of games
            List<ExternalGame> mySortedList = model.OrderBy(o => o.Name).ToList();
            // Obtain a list of letters in the alphabet
            List<char> alphabet = new List<char>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                foreach (var game in mySortedList)
                {
                    if (game.Name.StartsWith(c) && !alphabet.Contains(c))
                        alphabet.Add(c);
                }
            }            
            ViewBag.MySortedList = mySortedList;
            ViewBag.Alphabet = alphabet;
            return View(ViewBag);
        }
        public IActionResult Games(string id)
        {
            // Get the client
            var client = new RestClient(_configuration.GetValue<string>("WebSettings:MyExternalGamesEndPoint"));
            // Get the request
            var request = new RestRequest("/{id}", Method.GET);
            // Set the format of the information
            request.RequestFormat = DataFormat.Json;
            // Adds parameters for the request
            request.AddParameter("id", id, ParameterType.UrlSegment);
            // Get the response
            var response = client.Execute<List<ExternalGame>>(request);
            // Check if it is not successful
            if (!response.IsSuccessful) 
                return BadRequest(); 
            return View(response.Data[0]); 
        }
        public IActionResult Search()
        {
            // Get the client
            var client = new RestClient(_configuration.GetValue<string>("WebSettings:MyExternalGamesEndPoint"));
            // Get the request
            var request = new RestRequest(Method.GET);
            // Set the format of the information
            request.RequestFormat = DataFormat.Json;
            // Get the response
            var response = client.Execute<List<ExternalGame>>(request);
            // Check if it is not successful
            if (!response.IsSuccessful)
                return BadRequest();
            ViewBag.ShowTable = false;
            ViewBag.MySortedList = response.Data;
            return View();
        }
        public IActionResult Searching(string id)
        {
            // Get the client
            var client = new RestClient(_configuration.GetValue<string>("WebSettings:MyExternalGamesEndPoint"));
            // Get the request
            var request = new RestRequest("/{id}", Method.GET);
            // Set the format of the information
            request.RequestFormat = DataFormat.Json;
            // Adds parameters for the request
            request.AddParameter("id", id, ParameterType.UrlSegment);
            // Get the response
            var response = client.Execute<List<ExternalGame>>(request);
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.ShowTable = false;
                return View();
            }
            // Check if it is not successful
            if (!response.IsSuccessful)
                return BadRequest();
            ViewBag.ShowTable = true;
            ViewBag.MySortedList = response.Data;
            return View();
        }
    }
}