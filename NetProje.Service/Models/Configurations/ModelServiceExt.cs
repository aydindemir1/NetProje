using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetProje.Repository.Models;
using NetProje.Service.Models.AsyncMethods;
using NetProje.Service.Models.ModelCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Models.Configurations
{
    public static class ModelServiceExt
    {
        public static void AddModelService(this IServiceCollection services)
        {
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IModelRepository, ModelRepository>();
            
            services.AddValidatorsFromAssemblyContaining<ModelCreateRequestValidator>();
            services.AddScoped<NotFoundFilter>();
        }
    }
}
