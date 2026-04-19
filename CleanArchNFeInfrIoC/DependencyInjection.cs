using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CleanArchNFeInfraData.Context;
using CleanArchNF_eDomain.Interfaces;
using CleanArchNFeInfraData.Repository;

namespace CleanArchNFeInfrIoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                ));

            services.AddScoped<ICliente, ClienteRepository>();
            services.AddScoped<IEmpresa, EmpresaRepository>();
            services.AddScoped<CleanArchNF_eDomain.Interfaces.IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<INotaFiscal, NotaFiscalRepository>();
            services.AddScoped<CleanArchNF_eDomain.Interfaces.INotaFiscalRepository, NotaFiscalRepository>();
            services.AddScoped<IItemNotaFiscal, ItemNotaFiscalRepository>();

            // Application services
            services.AddScoped<CleanArchNFeApplication.Interfaces.INotaFiscalService, CleanArchNFeApplication.Services.NotaFiscalService>();
            services.AddScoped<CleanArchNFeApplication.Interfaces.IItemNotaFiscalService, CleanArchNFeApplication.Services.ItemNotaFiscalService>();

            return services;
        }
    }
}