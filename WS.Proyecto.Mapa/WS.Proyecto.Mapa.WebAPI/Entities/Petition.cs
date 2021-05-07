using System.Collections.ObjectModel;

namespace WS.Proyecto.Mapa.WebAPI.Entities
{
    public class Petition
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Username { get; set; }

        public string BoardGame { get; set; }

        Collection<int> PetitionsIds { get; set; } = new Collection<int>();
    }
}