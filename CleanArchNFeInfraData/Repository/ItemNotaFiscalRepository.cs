using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNFeDomain.Entities;
using CleanArchNF_eDomain.Interfaces;
using CleanArchNFeInfraData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchNFeInfraData.Repository
{
    public class ItemNotaFiscalRepository : IItemNotaFiscal
    {
        ApplicationDbContext _itemNotaContext;
        public ItemNotaFiscalRepository(ApplicationDbContext context)
        {
            _itemNotaContext = context;
        }

        public async Task AdicionarItemNotaFiscal(int idProduto, int quantidade, decimal valorUnitario)
        {
            var nota = await _itemNotaContext.NotasFiscais
        .Include(n => n.Itens)
        .FirstOrDefaultAsync(n => n.Id == idProduto);

            if (nota == null)
                throw new Exception("Nota fiscal não encontrada");

            var item = new ItemNotaFiscal(idProduto, quantidade, valorUnitario);

            nota.Itens.Add(item);

            await _itemNotaContext.SaveChangesAsync();
        }


        public async Task AtualizarItemNotaFiscal(int idProduto, int quantidade, decimal valorUnitario)
        {
            var item = await _itemNotaContext.itensNotaFiscal.FirstOrDefaultAsync(i => i.ProdutoId == idProduto);
            if (item != null)
            {
                item.Quantidade = quantidade;
                item.ValorUnitario = valorUnitario;
                await _itemNotaContext.SaveChangesAsync();
            }
        }

        public async Task<decimal> CalcularTotalItemNotaFiscal(int idProduto)
        {
            return await _itemNotaContext.itensNotaFiscal
                .Where(i => i.ProdutoId == idProduto)
                .Select(i => i.Quantidade * i.ValorUnitario)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal> CalcularValorTotalItemNotaFiscal(int idProduto)
        {
            return await _itemNotaContext.itensNotaFiscal
                .Where(i => i.ProdutoId == idProduto)
                .Select(i => i.Quantidade * i.ValorUnitario)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ItemNotaFiscal>> ObterItensNotaFiscal(int idNotaFiscal)
        {
            return await _itemNotaContext.itensNotaFiscal
                 .Where(i => i.ProdutoId == idNotaFiscal)
                 .ToListAsync();
        }

        public async Task<IEnumerable<ItemNotaFiscal>> ObterItensNotaFiscalPorProduto(int idProduto)
        {
            return await _itemNotaContext.itensNotaFiscal
                .Where(i => i.ProdutoId == idProduto)
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemNotaFiscal>> ObterTodosItensNotaFiscal()
        {
            return await _itemNotaContext.itensNotaFiscal.ToListAsync();
        }

        public async Task RemoverItemNotaFiscal(int idProduto)
        {
            var item = await _itemNotaContext.itensNotaFiscal.FirstOrDefaultAsync(i => i.ProdutoId == idProduto);
            if (item != null)
            {
                _itemNotaContext.itensNotaFiscal.Remove(item);
                await _itemNotaContext.SaveChangesAsync();
            }
        }
    }
}
