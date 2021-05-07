using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS.Proyecto.Mapa.Web.Models
{
    public class Petition
    {
        public Petition() { }
        public Petition(double latitude, double longitude, string username, string boardGame, string password)
        {
            Latitude = latitude;
            Longitude = longitude;
            Username = username;
            BoardGame = boardGame;
            Password = password;
        }

        public Petition(long id, double latitude, double longitude, string username, string boardGame, string password)
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
            Username = username;
            BoardGame = boardGame;
            Password = password;
        }
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Username { get; set; }
        public string BoardGame { get; set; }
        public string Password { get; set; }
    }
}
