namespace Presentation.Blazor.Configuration
{    public class HelperEndPoints
    {
        private const string BaseUrl = "https://localhost:7218/api";
        
        public static Uri Api(string action)
        {
            return new Uri($"{BaseUrl}/{action}");
        }
    }
}
