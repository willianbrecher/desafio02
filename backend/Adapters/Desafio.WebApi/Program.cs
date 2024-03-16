using Autofac;
using Autofac.Extensions.DependencyInjection;
using Desafio.Application;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;

try { 
    var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", true, false)
           .AddEnvironmentVariables()
           .Build();

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

    var builder = WebApplication.CreateBuilder(args);

    builder.WebHost.UseConfiguration(configuration);

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule(configuration)));
    builder.Host.UseSerilog(Log.Logger);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

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

    app.Services.GetService<DbContext>()?.Database.Migrate();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}
