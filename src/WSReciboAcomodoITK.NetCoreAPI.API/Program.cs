
using Swashbuckle.AspNetCore.SwaggerGen;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WSReciboAcomodoITK API", Version = "v1" });
});
builder.Services.AddScoped<WSReciboAcomodoITK.NetCoreAPI.Application.IReciboAcomodoService, WSReciboAcomodoITK.NetCoreAPI.Application.ReciboAcomodoService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WSReciboAcomodoITK API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
