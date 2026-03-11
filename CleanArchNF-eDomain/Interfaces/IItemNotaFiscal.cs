using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Entities;

namespace CleanArchNF_eDomain.Interfaces
{
    public interface IItemNotaFiscal
    {
        Task<List<ItemNotaFiscal>> ObterItensNotaFiscal(int idNotaFiscal);
        Task<IEnumerable<ItemNotaFiscal>> ObterTodosItensNotaFiscal();
        Task<IEnumerable<ItemNotaFiscal>> ObterItensNotaFiscalPorProduto(int idProduto);
        Task AdicionarItemNotaFiscal(int idProduto, int quantidade, decimal valorUnitario);
        Task<decimal> CalcularValorTotalItemNotaFiscal(int idProduto);
        Task<decimal> CalcularTotalItemNotaFiscal(int idProduto);
        Task AtualizarItemNotaFiscal(int idProduto, int quantidade, decimal valorUnitario);
        Task RemoverItemNotaFiscal(int idProduto);
    }
}
