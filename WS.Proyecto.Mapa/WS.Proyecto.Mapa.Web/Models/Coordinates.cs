using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS.Proyecto.Mapa.Web.Models
{
    public class Coordinates
    {
        public Coordinates(double latitude, double longitude)
        {
            Lat = latitude;
            Lng = longitude;
        }

        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
