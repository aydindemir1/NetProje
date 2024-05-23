using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetProje.API.Filters;
using NetProje.Repository;
using NetProje.Repository.Roles;
using NetProje.Repository.Users;
using NetProje.Service;
using NetProje.Service.Brands.Configurations;
using NetProje.Service.CacheService.Interfaces;
using NetProje.Service.CacheService.RedisCacheService;
using NetProje.Service.Cars.Configurations;
using NetProje.Service.Fuels.Configurations;
using NetProje.Service.Models.Configurations;
using NetProje.Service.Transmissions.Configurations;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICacheService, RedisCacheService>();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
        x => { x.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.GetName().Name); });
});

builder.Services.AddSingleton<RedisCacheService>(x =>
{
    return new RedisCacheService(builder.Configuration.GetConnectionString("Redis")!);
});

builder.Services.AddTransient<IDatabase>(sp =>
{
    var connectionMultiplexer = sp.GetRequiredService<IConnectionMultiplexer>();
    return connectionMultiplexer.GetDatabase();
});

builder.Services.AddSingleton(sp => "url");

builder.Services.Configure<ApiBehaviorOptions>(x => { x.SuppressModelStateInvalidFilter = true; });

builder.Services.AddAutoMapper(typeof(ServiceAssembly).Assembly);

// Add services to the container.

builder.Services.AddControllers(x => x.Filters.Add<ValidationFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddBrandService();
builder.Services.AddModelService();
builder.Services.AddCarService();
builder.Services.AddTransmissionService();
builder.Services.AddFuelService();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
