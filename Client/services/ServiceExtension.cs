using Client.Models;
using Client.Repos;
using Client.Repos.Interface;
using Client.services.Interface;

namespace Client.services
{
    public static class ServiceExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<ICalculateService, CalculateService>();
            services.AddDbContext<ClientContext>();

        }
    }
}
