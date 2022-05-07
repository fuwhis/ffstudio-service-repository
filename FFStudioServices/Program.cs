using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

using EntityModel.Context;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FFStudioServices.Helpers;
using Service.BusinessService.UserService;
using FFStudioServices.Authorization;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    var services = builder.Services;
    // Configuration Postgresql Services.
    services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
        .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

    services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        //options.SuppressMapClientErrors = true;
    });

    // Register The Database Context Services.
    services.AddDbContext<PostgreContext>(opt => opt
        //.UseInMemoryDatabase("2fStudioDB")
        .UseNpgsql(builder.Configuration.GetConnectionString("2fStudioDB"))
    );

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Add services CORs
    services.AddCors(c =>
    {
        c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IUserService, UserService>();

    // configure automapper with all automapper profiles from this assembly
    services.AddAutoMapper(typeof(Program));

    // configure DI for application services
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IUserService, UserService>();
}

// Declare A Builder
var app = builder.Build();
// Enable CORs
app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();
// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.Run();
