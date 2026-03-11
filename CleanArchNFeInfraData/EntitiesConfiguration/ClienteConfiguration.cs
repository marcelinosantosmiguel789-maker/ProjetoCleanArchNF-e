using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Entities;

namespace CleanArchNFeInfraData.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder) 
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(14);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(14);
            builder.Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(14);
            builder.HasData(
                new Cliente
                {
                    Id = 1,
                    Documento = "12345678901",
                    Nome = "Cliente 1",
                    Endereco = "Rua A, 123"
                },
                new Cliente
                {
                    Id = 2,
                    Documento = "98765432100",
                    Nome = "Cliente 2",
                    Endereco = "Avenida B, 456"
                }
            );
        }
    }
}
