using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WS.Proyecto.Mapa.Application.Model
{
    public class Petition
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Username { get; set; }
        public string BoardGame { get; set; }
        Collection<int> PetitionsIds { get; set; } = new Collection<int>();
    }
}
