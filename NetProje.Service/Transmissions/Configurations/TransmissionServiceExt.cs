using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetProje.Repository.Transmissions;
using NetProje.Service.Transmissions.AsyncMethods;
using NetProje.Service.Transmissions.TransmissionCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Transmissions.Configurations
{
    public static class TransmissionServiceExt
    {
        public static void AddTransmissionService(this IServiceCollection services)
        {
            services.AddScoped<ITransmissionService, TransmissionService>();
            services.AddScoped<ITransmissionRepository, TransmissionRepository>();

            services.AddValidatorsFromAssemblyContaining<TransmissionCreateRequestValidator>();
            services.AddScoped<NotFoundFilter>();
        }
    }
}
