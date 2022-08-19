using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;


namespace Persistence
{
    public static class PersistenceServiceRegistiration
    {
        public static void AddPersistenceInfrastructurer(this IServiceCollection services , IConfiguration _configuration)
        {
            services.AddDbContext<AppDbContext>
               (options => options.UseSqlServer(_configuration.GetConnectionString("NorthwindConnectionString")));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}
