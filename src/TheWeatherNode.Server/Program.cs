using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using TheWeatherNode.Core.Config;
using TheWeatherNode.Server.IoC;
using TheWeatherNode.WeatherService.OpenMeteo.Client;

var builder = WebApplication.CreateBuilder(args);
var appSettingsProvider = new AppSettingsProvider();

//Logging configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/weathernode-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

//HttpClient configuration
builder.Services.AddHttpClient<OpenMeteoClient>();

//Autofac configuration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new TheWeatherNodeModule());
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
