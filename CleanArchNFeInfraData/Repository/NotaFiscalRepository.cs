using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Interfaces;
using CleanArchNFeInfraData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchNFeDomain.Entities;
using CleanArchNF_eDomain.Enums;

namespace CleanArchNFeInfraData.Repository

{
    public class NotaFiscalRepository : INotaFiscal, CleanArchNF_eDomain.Interfaces.INotaFiscalRepository
    {
        ApplicationDbContext _notaFiscalContext;
        public NotaFiscalRepository(ApplicationDbContext context)
        {
            _notaFiscalContext = context;
        }
        public async Task<NotaFiscal> ObterNotaPorIdAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Include(n => n.Itens)
                .Include(n => n.Cliente)
                .Include(n => n.Empresa)
                .FirstOrDefaultAsync(n => n.Id == idNotaFiscal);
        }
        public async Task AdicionarItemNotaAsync(int idNotaFiscal, ItemNotaFiscal item)
        {
            var nota = await ObterNotaPorIdAsync(idNotaFiscal);
            if (nota != null)
            {
                nota.AdicionarItem(item);
                await SalvarNotaAsync(nota);
            }
        }

        // new name to match repository interface
        public async Task AtualizarClienteNotaAsync(int idNotaFiscal, Cliente cliente)
        {
            var nota = await _notaFiscalContext.NotasFiscais
                .FirstOrDefaultAsync(n => n.Id == idNotaFiscal);
            if (nota != null)
            {
                nota.Cliente = cliente;
                await _notaFiscalContext.SaveChangesAsync();
            }
        }

        // keep old name for compatibility
        public Task AtualizarClientNotaAsync(int idNotaFiscal, Cliente cliente)
            => AtualizarClienteNotaAsync(idNotaFiscal, cliente);

        public async Task AtualizarEmpresaNotaAsync(int idNotaFiscal, Empresa empresa)
        {
            var nota = await _notaFiscalContext.NotasFiscais
                .FirstOrDefaultAsync(n => n.Id == idNotaFiscal);
            if (nota != null)
            {
                nota.Empresa = empresa;
                await _notaFiscalContext.SaveChangesAsync();
            }
        }

        public async Task AtualizarItemNotaAsync(int idNotaFiscal, ItemNotaFiscal item)
        {
            var nota = await ObterNotaPorIdAsync(idNotaFiscal);
            if (nota != null)
            {
                // domain should decide how to update an item; here we add for simplicity
                nota.AdicionarItem(item);
                await SalvarNotaAsync(nota);
            }
        }

        // compatibility lowercase method
        public Task atualizarItemNotaAsync(int idNotaFiscal, ItemNotaFiscal item)
            => AtualizarItemNotaAsync(idNotaFiscal, item);

        public async Task AtualizarNumeroAsync(int idNotaFiscal, int numero)
        {
            var nota = await _notaFiscalContext.NotasFiscais
                .FirstOrDefaultAsync(n => n.Id == idNotaFiscal);
            if (nota != null)
            {
                nota.Numero = numero;
                await _notaFiscalContext.SaveChangesAsync();
            }
        }

        public async Task AtualizarSerieAsync(int idNotaFiscal, int serie)
        {
            var nota = await _notaFiscalContext.NotasFiscais
                .FirstOrDefaultAsync(n => n.Id == idNotaFiscal);
            if (nota != null)
            {
                nota.Serie = serie;
                await _notaFiscalContext.SaveChangesAsync();
            }
        }

        public async Task AtualizarStatusNotaAsync(int idNotaFiscal, StatusNotaFiscal status)
        {
            var nota = await _notaFiscalContext.NotasFiscais
                .FirstOrDefaultAsync(n => n.Id == idNotaFiscal);
            if (nota != null)
            {
                nota.Status = status;
                await _notaFiscalContext.SaveChangesAsync();
            }
        }

        public async Task<Cliente> ObterClienteNotaAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Where(n => n.Id == idNotaFiscal)
                .Select(n => n.Cliente)
                .FirstOrDefaultAsync();
        }

        public async Task<DateTime> ObterDataEmissaoNotaAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Where(n => n.Id == idNotaFiscal)
                .Select(n => n.DataEmissao)
                .FirstOrDefaultAsync();
        }

        public async Task<Empresa> ObterEmpresaNotaAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Where(n => n.Id == idNotaFiscal)
                .Select(n => n.Empresa)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal> ObterImpostosNotaAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Where(n => n.Id == idNotaFiscal)
                .Select(n => n.Itens.Sum(i => i.ValorUnitario * i.Quantidade)) // Exemplo de cálculo de impostos
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ItemNotaFiscal>> ObterItensNotaAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Where(n => n.Id == idNotaFiscal)
                .SelectMany(n => n.Itens)
                .ToListAsync();
        }

        public async Task<int> ObterNumeroNotaAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Where(n => n.Id == idNotaFiscal)
                .Select(n => n.Numero)
                .FirstOrDefaultAsync();
        }

        public async Task<int> ObterSerieNotaAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Where(n => n.Id == idNotaFiscal)
                .Select(n => n.Serie)
                .FirstOrDefaultAsync();
        }

        public async Task<StatusNotaFiscal> ObterStatusNotaAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Where(n => n.Id == idNotaFiscal)
                .Select(n => n.Status)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal> ObterTotalNotaAsync(int idNotaFiscal)
        {
            return await _notaFiscalContext.NotasFiscais
                .Where(n => n.Id == idNotaFiscal)
                .Select(n => n.Itens.Sum(i => i.ValorUnitario * i.Quantidade)) // Exemplo de cálculo do total
                .FirstOrDefaultAsync();
        }

        public async Task RemoverItemNotaAsync(int idNotaFiscal, int idProduto)
        {
            var nota = await ObterNotaPorIdAsync(idNotaFiscal);
            if (nota != null)
            {
                nota.RemoverItemPorProduto(idProduto);
                await SalvarNotaAsync(nota);
            }
        }

        public async Task SalvarNotaAsync(NotaFiscal nota)
        {
            if (nota == null) throw new ArgumentNullException(nameof(nota));
            _notaFiscalContext.NotasFiscais.Update(nota);
            await _notaFiscalContext.SaveChangesAsync();
        }
    }
}
