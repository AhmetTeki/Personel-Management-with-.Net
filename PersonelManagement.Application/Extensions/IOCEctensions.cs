using Microsoft.Extensions.DependencyInjection;
using PersonelManagement.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
