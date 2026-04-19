using CleanArchNFeApplication.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchNFeApplication.Interfaces
{
    public interface IItemNotaFiscalService
    {
        Task AdicionarItemNotaAsync(int idNotaFiscal, ItemNotaFiscalDTO itemDto);
        Task<IEnumerable<ItemNotaFiscalDTO>> ObterItensNotaAsync(int idNotaFiscal);
        Task RemoverItemNotaAsync(int idNotaFiscal, int idProduto);
    }
}
