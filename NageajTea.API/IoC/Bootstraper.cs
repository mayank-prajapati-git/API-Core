namespace NageajTea.API.IoC
{
    public static class Bootstraper
    {
        public static void Configure(IServiceCollection services)
        {
            Configure(services, NagrajTea.Repository.IoC.Module.GetTypes());
            Configure(services, NagrajTea.Service.IoC.Module.GetTypes());
            Configure(services, Module.GetTypes());
        }

        private static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var type in types)
                services.AddScoped(type.Key, type.Value);
        }

    }
}
