using CleanArchNF_eDomain.Enums;
using CleanArchNFeApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchNFeApplication.Interfaces
{
    public interface INotaFiscalService
    {
        Task<int> ObterNumeroNotaAsync(int idNotaFiscal);
        Task<int> ObterSerieNotaAsync(int idNotaFiscal);
        Task AtualizarNumeroAsync(int idNotaFiscal, int numero);
        Task AtualizarSerieAsync(int idNotaFiscal, int serie);
        Task<ClienteDTO> ObterClienteNotaAsync(int idNotaFiscal);
        Task<EmpresaDTO> ObterEmpresaNotaAsync(int idNotaFiscal);
        Task AtualizarClienteNotaAsync(int idNotaFiscal, ClienteDTO clienteDto);
        Task AtualizarEmpresaNotaAsync(int idNotaFiscal, EmpresaDTO empresaDto);
        Task<IEnumerable<ItemNotaFiscalDTO>> ObterItensNotaAsync(int idNotaFiscal);
        Task AdicionarItemNotaAsync(int idNotaFiscal, ItemNotaFiscalDTO itemDto);
        Task AtualizarItemNotaAsync(int idNotaFiscal, ItemNotaFiscalDTO itemDto);
        Task RemoverItemNotaAsync(int idNotaFiscal, int idProduto);
        Task<decimal> ObterTotalNotaAsync(int idNotaFiscal);
        Task<decimal> ObterImpostosNotaAsync(int idNotaFiscal);
        Task<StatusNotaFiscal> ObterStatusNotaAsync(int idNotaFiscal);
        Task AtualizarStatusNotaAsync(int idNotaFiscal, StatusNotaFiscal status);
        Task<DateTime> ObterDataEmissaoNotaAsync(int idNotaFiscal);
    }
}
