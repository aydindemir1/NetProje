using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetProje.Repository.Brands;
using NetProje.Service.Brands.AsyncMethods;
using NetProje.Service.Brands.BrandCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Brands.Configurations
{
    public static class BrandServiceExt
    {
        public static void AddBrandService(this IServiceCollection services)
        {
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddValidatorsFromAssemblyContaining<BrandCreateRequestValidator>();
            services.AddScoped<NotFoundFilter>();
        }
    }
}
