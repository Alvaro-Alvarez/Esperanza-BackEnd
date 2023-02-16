namespace Esperanza.Core.Models.Request
{
    public class GetRecommended
    {
        public GetRecommended()
        {
            ProductCodes = new List<string>();
        }

        public List<string> ProductCodes { get; set; }
    }
}
