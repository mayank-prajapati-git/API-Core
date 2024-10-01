namespace NageajTea.API.IoC
{
    public class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            foreach (var type in Module.GetSingleTypes())
                services.AddScoped(type);
            Bootstraper.Configure(services);
        }
    }
}
