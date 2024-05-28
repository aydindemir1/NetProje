using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
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
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using StackExchange.Redis;
using System.Collections.ObjectModel;
using System.Data;
using System.Net;


var builder = WebApplication.CreateBuilder(args);

// Serilog konfigürasyonu
var connectionString = builder.Configuration.GetConnectionString("SqlServer");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
        connectionString: connectionString,
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "Logs",
            AutoCreateSqlTable = true
        },
        columnOptions: new ColumnOptions
        {
            AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn { ColumnName = "UserName", DataType = SqlDbType.NVarChar, DataLength = 50 },
                new SqlColumn { ColumnName = "MachineName", DataType = SqlDbType.NVarChar, DataLength = 50 }
            }
        })
    .CreateLogger();

// Serilog'u kullanacak þekilde yapýlandýrma
builder.Host.UseSerilog();

Log.Information("Starting up the host");



// Daha sonra diðer middleware'ler ve endpoint tanýmlamalarý gelir


// Servislerin eklenmesi
//builder.Services.AddScoped<ICacheService, RedisCacheService>();
builder.Services.AddScoped<ICacheService>(provider => new RedisCacheService("localhost:6379"));
//builder.Services.AddScoped<IRedisCacheService>(provider => new RedisCacheService("localhost:6379"));

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

builder.Services.AddControllers(x => x.Filters.Add<ValidationFilter>());

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

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionHandlerPathFeature!.Error;

        Log.Error(exception, "An error occurred while fetching all brands");

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new
        {
            Data = string.Empty,
            Errors = new List<string> { "An error occurred while processing your request." }
        });
    });
});

// Middleware sýralamasý
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

Log.CloseAndFlush();

