using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS.Proyecto.Mapa.Web.Models
{
    public class Image
    {
        public Image() { }
        public Image(string thumb, string small, string medium, string large, string original)
        {
            Thumb = thumb;
            Small = small;
            Medium = medium;
            Large = large;
            Original = original;
        }
        public string Thumb { get; set; }
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
        public string Original { get; set; }
    }
}
