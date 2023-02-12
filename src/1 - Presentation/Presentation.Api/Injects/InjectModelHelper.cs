namespace Domain.Commons
{
    public static class InjectModelHelper
    {
        public static IServiceCollection InjectModel(this IServiceCollection services)
        {
            //services.AddScoped<>();
            return services;
        }
    }
}
