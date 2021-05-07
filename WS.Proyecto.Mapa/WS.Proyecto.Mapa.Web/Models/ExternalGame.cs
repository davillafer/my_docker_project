using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WS.Proyecto.Mapa.Web.Models
{
    public class ExternalGame
    {
        public ExternalGame() { }
        public ExternalGame(string id, string name, int yearPublished, int minPlayers, int maxPlayers, int minPlaytime, int maxPlaytime, string description, string descriptionPreview, string imageURL, string thumbURL, Image images, string uRL, string price, string discount, string primaryPublisher, List<string> publishers, List<string> mechanics, List<string> categories, List<string> designers, List<string> developers, List<string> artists, List<string> names, int numUserRatings, double averageUserRating, string officialURL, string rulesURL, double weightAmount, string weightUnits, double sizeHeight, double sizeWidth, double sizeDepth, string sizeUnits, int redditAllTimeCount, int redditWeekCount, int redditDayCount, double historicalLowPrice)
        {
            Id = id;
            Name = name;
            YearPublished = yearPublished;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            MinPlaytime = minPlaytime;
            MaxPlaytime = maxPlaytime;
            Description = description;
            DescriptionPreview = descriptionPreview;
            ImageURL = imageURL;
            ThumbURL = thumbURL;
            Images = images;
            URL = uRL;
            Price = price;
            Discount = discount;
            PrimaryPublisher = primaryPublisher;
            Publishers = publishers;
            Mechanics = mechanics;
            Categories = categories;
            Designers = designers;
            Developers = developers;
            Artists = artists;
            Names = names;
            NumUserRatings = numUserRatings;
            AverageUserRating = averageUserRating;
            OfficialURL = officialURL;
            RulesURL = rulesURL;
            WeightAmount = weightAmount;
            WeightUnits = weightUnits;
            SizeHeight = sizeHeight;
            SizeWidth = sizeWidth;
            SizeDepth = sizeDepth;
            SizeUnits = sizeUnits;
            RedditAllTimeCount = redditAllTimeCount;
            RedditWeekCount = redditWeekCount;
            RedditDayCount = redditDayCount;
            HistoricalLowPrice = historicalLowPrice;
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
