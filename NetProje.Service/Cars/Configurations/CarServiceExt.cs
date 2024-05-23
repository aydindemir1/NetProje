using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetProje.Repository.Cars;
using NetProje.Service.Cars.AsyncMethods;
using NetProje.Service.Cars.CarCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Cars.Configurations
{
    public static class CarServiceExt
    {
        public static void AddCarService(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarRepository, CarRepository>();

            services.AddValidatorsFromAssemblyContaining<CarCreateRequestValidator>();
            services.AddScoped<NotFoundFilter>();
        }
    }
}
