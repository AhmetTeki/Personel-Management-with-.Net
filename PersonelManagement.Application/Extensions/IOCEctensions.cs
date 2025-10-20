using Microsoft.Extensions.DependencyInjection;
using PersonelManagement.Application.Requests;

namespace PersonelManagement.Application.Extensions
{
   public static class IOCEctensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration=>configuration.RegisterServicesFromAssembly(typeof(LoginRequest).Assembly));
        }
    }
}
