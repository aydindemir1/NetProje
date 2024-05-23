using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetProje.Repository.Fuels;
using NetProje.Service.Fuels.AsyncMethods;
using NetProje.Service.Fuels.FuelCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Fuels.Configurations
{
    public static class FuelServiceExt
    {
        public static void AddFuelService(this IServiceCollection services)
        {
            services.AddScoped<IFuelService, FuelService>();
            services.AddScoped<IFuelRepository, FuelRepository>();

            services.AddValidatorsFromAssemblyContaining<FuelCreateRequestValidator>();
            services.AddScoped<NotFoundFilter>();
        }
    }
}
