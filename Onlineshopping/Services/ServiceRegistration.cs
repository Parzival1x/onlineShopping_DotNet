using Microsoft.Extensions.DependencyInjection;

namespace Onlineshopping.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ProductServices>();
            services.AddScoped<UsersServices>();
            services.AddScoped<CommentServices>();
            services.AddScoped<CartServices>();
            return services;
        }
    }
}
