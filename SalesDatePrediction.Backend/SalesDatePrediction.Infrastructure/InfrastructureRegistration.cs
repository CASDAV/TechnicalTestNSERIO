using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesDatePrediction.Domain.Interfaces.Repositories;
using SalesDatePrediction.Infrastructure.Persistance;
using SalesDatePrediction.Infrastructure.Persistance.Repositories;

namespace SalesDatePrediction.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<SalesPredictionDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IDataAccessRepository, DataAccessRepository>();

            return services;
        }
    }
}
