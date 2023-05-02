namespace Esperanza.Core.Models
{
    public class Phone : Entity
    {
        public string? CountryCode { get; set; }
        public string? CityCode { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
