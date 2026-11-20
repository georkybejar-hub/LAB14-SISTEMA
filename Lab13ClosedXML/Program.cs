using Lab13ClosedXML.Application.Interfaces;
using Lab13ClosedXML.Application.UseCases.Reports.Queries;
using Lab13ClosedXML.Infrastructure.Data;
using Lab13ClosedXML.Infrastructure.Repositories;
using Lab13ClosedXML.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IExcelService, ExcelService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetClientsReportQuery).Assembly));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Swagger habilitado tambien en produccion para probar la API desplegada
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Lab13 Reportes API v1");
});

// En Render el HTTPS lo maneja la plataforma; solo redirigimos en local
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.MapControllers();

app.Run();