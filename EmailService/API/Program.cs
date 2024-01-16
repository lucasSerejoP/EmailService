using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using API.Application.Commands;
using API.Application.Queries;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using INFRA.Data.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllers();

// Adicionar o DbContext
builder.Services.AddDbContext<>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar o MediatR


// Adicionar o repositório

// Adicionar o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EmailService API",
        Description = "Api Email Service",
        Version = "v1"
    });
    var xmlFile = $"EmailService.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
// Adicionar o IDbConnection
builder.Services.AddTransient<IDbConnection>(provider => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
// Adicionar as Queries

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "EmailService API V1");
    options.EnableFilter();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();