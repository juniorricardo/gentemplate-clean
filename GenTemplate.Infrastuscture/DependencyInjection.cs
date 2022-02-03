using GenTemplate.Application.Common.Interfaces;
using GenTemplate.Infrastuscture.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GenTemplate.Infrastuscture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient("jsonplaceholder")
                .ConfigureHttpClient(options =>
                {
                    options.BaseAddress = new System.Uri("http://jsonplaceholder.typicode.com");
                });

            services.AddTransient<IPostService, PostService>();

            return services;
        }
    }
}
