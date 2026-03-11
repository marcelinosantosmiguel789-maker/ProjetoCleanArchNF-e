using CleanArchNFeInfraData.Context;
using CleanArchNFeInfraData.Repository;
using CleanArchNF_eDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchNFeInfraIoC
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
            services.AddScoped<INotaFiscal, NotaFiscalRepository>();
            services.AddScoped<IItemNotaFiscal, ItemNotaFiscalRepository>();

            return services;
        }
    }
}