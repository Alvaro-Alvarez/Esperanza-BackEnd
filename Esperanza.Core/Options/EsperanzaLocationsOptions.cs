namespace Esperanza.Core.Options
{
    public class EsperanzaLocations
    {
        public List<Location> Locations { get; set; }
    }

    public class Location
    {
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
