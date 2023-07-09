using Gruden.Data;
using Gruden.Data.Repos;
using Gruden.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
 
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
// Add Cors
var allowSpecificOriginsPolicy = "_allowSpecificOriginsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOriginsPolicy,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44492");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.AddControllers() 
                    .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        });

builder.Services.AddDbContextFactory<PersonDbContext>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();


var app = builder.Build();

var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(allowSpecificOriginsPolicy);

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}");

app.MapFallbackToFile("index.html"); ;

app.Run();
