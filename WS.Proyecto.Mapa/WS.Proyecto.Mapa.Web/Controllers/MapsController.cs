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
    public class MapsController : Controller
    {
        private IConfiguration _configuration;
        public MapsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


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
            ViewBag.coordinates = aux;
            return View();
        }
    }
}