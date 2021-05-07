using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WS.Proyecto.Mapa.Application.Model
{
    public class ExternalGame
    {
        private JObject json;
        public ExternalGame(JObject json)
        {
            this.json = json;
            Id = checkStringValue("id");
            Name = checkStringValue("name");
            YearPublished = checkIntValue("year_published");
            MinPlayers = checkIntValue("min_players"); 
            MaxPlayers = checkIntValue("max_players");
            MinPlaytime = checkIntValue("min_playtime");
            MaxPlaytime = checkIntValue("max_playtime");
            Description = checkStringValue("description");
            DescriptionPreview = checkStringValue("description_preview");
            ImageURL = checkStringValue("image_url");
            ThumbURL = checkStringValue("thumb_url");
            var imagesArray = json["images"].ToArray();
            Images = new Image(checkStringValue((string)imagesArray[0]), checkStringValue((string)imagesArray[1]), checkStringValue((string)imagesArray[2]),
                checkStringValue((string)imagesArray[3]), checkStringValue((string)imagesArray[4]));
            URL = checkStringValue("url");
            Price = checkStringValue("price");
            Discount = checkStringValue("discount");
            PrimaryPublisher = checkStringValue("primary_publisher");
            Publishers = json["publishers"].ToObject<List<string>>();
            Mechanics = checkArrayValue("mechanics");
            Categories = checkArrayValue("categories");
            Designers = json["designers"].ToObject<List<string>>();
            Developers = json["developers"].ToObject<List<string>>();
            Artists = json["artists"].ToObject<List<string>>();
            Names = json["names"].ToObject<List<string>>();
            NumUserRatings = checkIntValue("num_user_ratings");
            AverageUserRating = checkDoubleValue("average_user_rating");
            OfficialURL = checkStringValue("official_url");
            RulesURL = checkStringValue("rules_url");
            WeightAmount = checkDoubleValue("weight_amount");
            WeightUnits = checkStringValue("weight_units");
            SizeHeight = checkDoubleValue("size_height");
            SizeWidth = checkDoubleValue("size_width"); 
            SizeDepth = checkDoubleValue("size_depth");
            SizeUnits = checkStringValue("size_units");
            RedditAllTimeCount = checkIntValue("reddit_all_time_count");
            RedditWeekCount = checkIntValue("reddit_week_count");
            RedditDayCount = checkIntValue("reddit_day_count");
            HistoricalLowPrice = checkDoubleValue("historical_low_price");
        }
        private string checkStringValue(string param)
        {
            return string.IsNullOrEmpty((string)json[param]) ? "_error" : json[param].ToString();
            // return (this.json[param] ?? "_error").ToString(); // Not valid because some values are empty :( it was cool
        }
        private int checkIntValue(string param)
        {
            return string.IsNullOrEmpty((string)json[param]) ? -1 : int.Parse(json[param].ToString());
            // return int.Parse((this.json[param] ?? "-1").ToString());
        }
        private double checkDoubleValue(string param)
        {
            return string.IsNullOrEmpty((string)json[param]) ? -1 : double.Parse(json[param].ToString());
            // return double.Parse((json[param] ?? "-1").ToString());
        }
        private List<string> checkArrayValue(string param)
        {
            var myArray = json[param].ToArray();
            var myList = new List<string>();
            foreach (JToken token in myArray)
            {
                myList.Add(checkStringValue((String)token.First.First));
            }
            return myList;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int YearPublished { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlaytime { get; set; }
        public int MaxPlaytime { get; set; }
        public string Description { get; set; }
        public string DescriptionPreview { get; set; }
        public string ImageURL { get; set; }
        public string ThumbURL { get; set; }
        public Image Images { get; set; }
        public string URL { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string PrimaryPublisher { get; set; }
        public List<string> Publishers { get; set; }
        public List<string> Mechanics { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Designers { get; set; }
        public List<string> Developers { get; set; }
        public List<string> Artists { get; set; }
        public List<string> Names { get; set; }
        public int NumUserRatings { get; set; }
        public double AverageUserRating { get; set; }
        public string OfficialURL { get; set; }
        public string RulesURL { get; set; }
        public double WeightAmount { get; set; }
        public string WeightUnits { get; set; }
        public double SizeHeight { get; set; }
        public double SizeWidth { get; set; }
        public double SizeDepth { get; set; }
        public string SizeUnits { get; set; }
        public int RedditAllTimeCount { get; set; }
        public int RedditWeekCount { get; set; }
        public int RedditDayCount { get; set; }
        public double HistoricalLowPrice { get; set; }
    }


}
