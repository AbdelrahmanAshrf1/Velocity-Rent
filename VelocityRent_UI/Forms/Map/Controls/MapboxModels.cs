using System.Collections.Generic;

namespace Velocity_Rent.Map.Controls
{
    public class MapboxSuggestResponse
    {
        public List<MapboxSuggestion> suggestions { get; set; }
    }
    public class MapboxSuggestion
    { 
        public string name { get; set; }
        public string mapbox_id { get; set; }
        public string place_formatted { get; set; }
        public string full_address { get; set; }
        public MapboxContext context { get; set; }
    }
    public class MapboxRetrieveResponse
    {
        public List<MapboxFeature> features { get; set; }
    }
    public class MapboxFeature
    {
        public MapboxGeometry geometry { get; set; }
        public MapboxProperties properties { get; set; }
    }
    public class MapboxGeometry
    {
        public List<double> coordinates { get; set; }
    }
    public class MapboxProperties
    {
        public string name { get; set; }
        public string full_address { get; set; }
        public MapboxContext context { get; set; }
    }
    public class MapboxContext
    { 
        public MapboxContextItem country { get; set; }
        public MapboxContextItem region { get; set; }
        public MapboxContextItem postcode { get; set; }
        public MapboxContextItem place { get; set; }
    }
    public class MapboxContextItem
    {
        public string name { get; set;}
    }
}
