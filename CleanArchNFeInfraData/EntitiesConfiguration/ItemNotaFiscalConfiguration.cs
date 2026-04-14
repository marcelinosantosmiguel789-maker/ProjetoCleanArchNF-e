using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNFeDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchNFeInfraData.EntitiesConfiguration
{
    public class ItemNotaFiscalConfiguration : IEntityTypeConfiguration<ItemNotaFiscal>
    {
        public void Configure(EntityTypeBuilder<ItemNotaFiscal> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.ProdutoId)
                .IsRequired();
            builder.Property(i => i.Descricao)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(i => i.Quantidade)
                .IsRequired();
            builder.Property(i => i.ValorUnitario)
                .IsRequired()
                .HasPrecision(18, 2);
            builder.Property(i => i.Total)
                .IsRequired()
                .HasPrecision(18, 2);
            builder.Property(i => i.ValorImpostos)
                .IsRequired()
                .HasPrecision(18, 2);
            builder.HasData(
                new ItemNotaFiscal
                {
                    Id = 1,
                    ProdutoId = 1,
                    Descricao = "Produto A",
                    Quantidade = 10,
                    ValorUnitario = 100.00m,
                    Total = 1000.00m,
                    ValorImpostos = 150.00m
                },
                new ItemNotaFiscal
                {
                    Id = 2,
                    ProdutoId = 2,
                    Descricao = "Produto B",
                    Quantidade = 5,
                    ValorUnitario = 200.00m,
                    Total = 1000.00m,
                    ValorImpostos = 200.00m
                }
            );
        }
    }
}
