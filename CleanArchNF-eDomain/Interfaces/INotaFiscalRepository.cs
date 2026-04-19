using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNFeDomain.Entities;
using CleanArchNF_eDomain.Enums;

namespace CleanArchNF_eDomain.Interfaces
{
    public interface INotaFiscalRepository
    {
        Task<NotaFiscal> ObterNotaPorIdAsync(int idNotaFiscal);
        Task SalvarNotaAsync(NotaFiscal nota);
        Task AdicionarItemNotaAsync(int idNotaFiscal, ItemNotaFiscal item);
        Task AtualizarClienteNotaAsync(int idNotaFiscal, Cliente cliente);
        Task AtualizarEmpresaNotaAsync(int idNotaFiscal, Empresa empresa);
        Task AtualizarItemNotaAsync(int idNotaFiscal, ItemNotaFiscal item);
        Task RemoverItemNotaAsync(int idNotaFiscal, int idProduto);
        Task AtualizarNumeroAsync(int idNotaFiscal, int numero);
        Task AtualizarSerieAsync(int idNotaFiscal, int serie);
        Task AtualizarStatusNotaAsync(int idNotaFiscal, StatusNotaFiscal status);
    }
}
