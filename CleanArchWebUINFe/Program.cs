using CleanArchNFeInfrIoC;
using CleanArchWebUINFe.Middleware;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registrar AutoMapper (assegurando que os Profiles nas assemblies sejam carregados)
// Usa overload com Action para evitar ambiguidades de overload em diferentes versões
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddInfrastructure(builder.Configuration);

// Enable Swagger (package Swashbuckle.AspNetCore is referenced in project)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NF-e API v1"));
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// Global exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Expose Program for integration tests
public partial class Program { }
