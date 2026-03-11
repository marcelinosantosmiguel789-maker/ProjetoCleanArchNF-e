using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Entities;
using CleanArchNF_eDomain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchNFeInfraData.EntitiesConfiguration
{
    public class NotaFiscalConfiguration : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.HasKey(nf => nf.Id);

            builder.Property(nf => nf.Numero)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(nf => nf.Serie)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(nf => nf.Cliente)
                .WithMany()
                .HasForeignKey(nf => nf.ClienteId);

            builder.HasOne(nf => nf.Empresa)
                .WithMany()
                .HasForeignKey(nf => nf.EmpresaId);

            builder.HasMany(nf => nf.Itens);

            builder.Property(nf => nf.Total)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(nf => nf.Impostos)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(nf => nf.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(nf => nf.DataEmissao)
                .IsRequired();

        }
    }
}
