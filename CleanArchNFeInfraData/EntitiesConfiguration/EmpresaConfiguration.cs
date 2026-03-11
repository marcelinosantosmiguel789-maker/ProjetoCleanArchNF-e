using CleanArchNF_eDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchNFeInfraData.EntitiesConfiguration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Cnpj)
                .IsRequired()
                .HasMaxLength(14);
            builder.Property(e => e.RazaoSocial)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Endereco)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasData(
                new Empresa
                {
                    Id = 1,
                    Cnpj = "12345678000100",
                    RazaoSocial = "Empresa Exemplo LTDA",
                    Endereco = "Rua Exemplo, 123, Cidade, Estado"
                }
            );

        }
    }
}
