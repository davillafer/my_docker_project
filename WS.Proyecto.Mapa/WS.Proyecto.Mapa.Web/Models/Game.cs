using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS.Proyecto.Mapa.Web.Model
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OfficialURL { get; set; }
        public string Description { get; set; }
        public string RulesURL { get; set; }
    }
}
