using Microsoft.Extensions.DependencyInjection;

namespace Bibliotheque.IntefaceMethode
{
    public static class MyConfigServices
    {
        public static IServiceCollection AddConfigGroup(
             this IServiceCollection services, IConfiguration config)
        {
            //int p1 = int.Parse(config.GetSection("TXT1").Value);
            //int p2 = int.Parse(config.GetSection("TXT2").Value);

            services.Configure<MyOptions>(options =>
            {
                options.opt1 = 1;
                options.opt2 = 2;
            });

            return services;
        }

        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<Fidele, Denis>();
            services.AddScoped<Fidele, Denis>();

            return services;
        }
    }
}
