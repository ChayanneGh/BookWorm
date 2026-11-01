using BookWorm.Hub.Service;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<CFactory>();
builder.Services.AddScoped<DevolucionSrv>();
builder.Services.AddScoped<EstudianteSrv>();
builder.Services.AddScoped<LibroSrv>();
builder.Services.AddScoped<PrestamoSrv>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<CFactory>();
    await factory.Initialize();
}

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
