using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS.Proyecto.Mapa.Application.Model
{
    public class Game
    {
        public string Name { get; set; }
        public double ProductPrice { get; set; }
        public double ShippingPrice { get; set; }
        public double FinalPrice => (ProductPrice + ShippingPrice) * 1.20;
        public long Votes { get; set; }
    }
}
