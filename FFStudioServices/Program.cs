using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

using FFStudioServices.Context;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuration Postgresql Services.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        //options.SuppressMapClientErrors = true;
    });

// Register The Database Context Services.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<PostgreContext>(opt => opt
    .UseInMemoryDatabase("2fStudioDB")
    //.UseNpgsql(Configuration.GetConnectionString("2fStudioDB"))

);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("ToDoList"));


// Add services CORs
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
// Enable CORs
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
