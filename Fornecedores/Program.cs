using Microsoft.EntityFrameworkCore;
using Fornecedores.Domain.Interfaces;
using Fornecedores.Infrastructure.Data;
using Fornecedores.Application.Mappings;
using Fornecedores.Application.Services;
using Fornecedores.Application.Interfaces;
using Fornecedores.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Fornecedores.Api",
        Version = "v1"
    });
    c.EnableAnnotations();
});

// Configurar DbContext
builder.Services.AddDbContext<FornecedoresDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositório
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();

// Registrar serviço
builder.Services.AddScoped<IFornecedorService, FornecedorService>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fornecedores.API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


foreach (var descriptor in app.Services.GetRequiredService<EndpointDataSource>().Endpoints)
{
    Console.WriteLine($"Endpoint: {descriptor.DisplayName}");
}

app.Run();
