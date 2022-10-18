using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using AppraisalTool.Api.Middleware;
using AppraisalTool.Application;
using AppraisalTool.Application.Contracts;
using AppraisalTool.Infrastructure;
using AppraisalTool.Persistence;
using AppraisalTool.Identity;
using AppraisalTool.Api.Services;
using AppraisalTool.Api.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using AppraisalTool.Api.SwaggerHelper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



//SERILOG IMPLEMENTATION

IConfiguration configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configurationBuilder)
    .CreateBootstrapLogger().Freeze();

new LoggerConfiguration()
    .ReadFrom.Configuration(configurationBuilder)
    .CreateLogger();

builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));


// Add services to the container.

//readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


IConfiguration Configuration = builder.Configuration;
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var services = builder.Services;

string Urls = Configuration.GetSection("URLWhiteListings").GetSection("URLs").Value;
services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins(Urls).AllowAnyHeader().AllowAnyMethod();
        });
});
services.AddApplicationServices();

services.AddInfrastructureServices(Configuration);
services.AddPersistenceServices(Configuration);
services.AddIdentityServices(Configuration);
services.AddScoped<ILoggedInUserService, LoggedInUserService>();
services.AddSwaggerExtension();
services.AddSwaggerVersionedApiExplorer();
services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
services.AddControllers();
services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"bin\debug\configuration"));
services.AddHealthcheckExtensionService(Configuration);

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//ValidateTokenWithParameters(builder.Services, builder.Configuration);

//void ValidateTokenWithParameters(IServiceCollection services, ConfigurationManager configuration)
//{
//    var JwtSecret = configuration["JwtSettings:Key"];
//    var issuer = configuration["JwtSettings:Issuer"];
//    var audience = configuration["JwtSettings:Audience"];
//    var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret));
//    var tokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidIssuer = issuer,

//        ValidateAudience = true,
//        ValidAudience = audience,

//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = symmetricKey,

//        ValidateLifetime = true
//    };

//    builder.Services.AddAuthentication(u =>
//    {
//        u.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        u.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    }).AddJwtBearer(u => u.TokenValidationParameters = tokenValidationParameters);
//}

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    try
    {
        Log.Information("Application Starting");
    }
    catch (Exception ex)
    {
        Log.Warning(ex, "An error occured while starting the application");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();


// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
// specifying the Swagger JSON endpoint.  
IApiVersionDescriptionProvider provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwaggerUI(
options =>
{
    // build a swagger endpoint for each discovered API version  
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});

app.UseCustomExceptionHandler();

app.UseCors("Open");

app.UseAuthorization();
app.MapControllers();

//adding endpoint of health check for the health check ui in UI format
app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

//map healthcheck ui endpoing - default is /healthchecks-ui/
app.MapHealthChecksUI();

app.Run();

//For Integration test
public partial class Program { }
