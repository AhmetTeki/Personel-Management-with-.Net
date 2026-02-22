using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonelManagement.Application.Interfaces;
using PersonelManagement.Persistance.Context;
using PersonelManagement.Persistance.Repositories;

namespace PersonelManagement.Persistance
{
    public static class IOCExtentions
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonelManagementContext>(opt => { opt.UseSqlServer(configuration.GetConnectionString("Local")); });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
        }
    }
}