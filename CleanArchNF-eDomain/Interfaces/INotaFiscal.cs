using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Entities;
using CleanArchNF_eDomain.Enums;

namespace CleanArchNF_eDomain.Interfaces
{
    public interface INotaFiscal
    {
        Task<int>ObterNumeroNotaAsync(int idNotaFiscal);
        Task<int> ObterSerieNotaAsync(int idNotaFiscal);
        Task AtualizarNumeroAsync(int idNotaFiscal, int numero);
        Task AtualizarSerieAsync(int idNotaFiscal, int serie);
        Task<Cliente> ObterClienteNotaAsync(int idNotaFiscal);
        Task<Empresa> ObterEmpresaNotaAsync(int idNotaFiscal);
        Task AtualizarClientNotaAsync(int idNotaFiscal, Cliente cliente);
        Task AtualizarEmpresaNotaAsync(int idNotaFiscal, Empresa empresa);
        Task<IEnumerable<ItemNotaFiscal>> ObterItensNotaAsync(int idNotaFiscal);
        Task AdicionarItemNotaAsync(int idNotaFiscal, ItemNotaFiscal item);
        Task atualizarItemNotaAsync(int idNotaFiscal, ItemNotaFiscal item);
        Task RemoverItemNotaAsync(int idNotaFiscal, int idProduto);
        Task<decimal> ObterTotalNotaAsync(int idNotaFiscal);
        Task<decimal> ObterImpostosNotaAsync(int idNotaFiscal);
        Task<StatusNotaFiscal> ObterStatusNotaAsync(int idNotaFiscal);
        Task AtualizarStatusNotaAsync(int idNotaFiscal, StatusNotaFiscal status);
         Task<DateTime> ObterDataEmissaoNotaAsync(int idNotaFiscal);

    }
}
