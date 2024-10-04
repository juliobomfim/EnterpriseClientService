using EnterpriseClientService.CrossCutting.InversionOfControl;
using EnterpriseClientService.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen( opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EnterpriseClientServiceApi",
        Description = "WebApi to interact with EnterpriseClient data.",
    });
});


builder.Services.ConfigureDataServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(op =>
    {
        op.AllowAnyHeader();
        op.AllowAnyOrigin();
        op.AllowAnyMethod();
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

ApplyMigrations();

app.Run();

// https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli
void ApplyMigrations() 
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<EnterpriseClientServiceContext>();
        if (db.Database.GetMigrations().Any())
            db.Database.Migrate();
    }
}