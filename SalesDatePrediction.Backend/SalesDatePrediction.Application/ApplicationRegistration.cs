using Microsoft.Extensions.DependencyInjection;
using SalesDatePrediction.Application.Mapper;
using SalesDatePrediction.Application.Services;

namespace SalesDatePrediction.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(c => { }, typeof(MappingProfile));

            services.AddScoped<ApplicationServices>();

            return services;
        }
    }
}
