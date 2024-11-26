namespace DemoAPIProvicesVN.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddServiceCollectionExtensions(this IServiceCollection services) 
        {
            services
                .AddSingletonServices()
                .AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
                });

            return services;
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbServices, DbServices>();
            return services;
        }
    }
}
