namespace Presentation.Blazor.Configuration
{    public class HelperEndPoints
    {
        private const string BaseUrl = "https://localhost:7218";

        public static Uri Api(string api)
        {
            return new Uri($"{BaseUrl}/{api}");
        }
    }
}
