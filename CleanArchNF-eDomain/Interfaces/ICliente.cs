using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNFeDomain.Entities;
using CleanArchNF_eDomain.Validation;

namespace CleanArchNF_eDomain.Interfaces
{
    public interface ICliente
    {
        Task<Cliente> ObterClientePorId(int idCliente);
        Task<IEnumerable<Cliente>> ObterClientesPorNome(string nome);
        Task<string> ObterNomeCliente(int idCliente);
        Task<string> ObterDocumentoCliente(int idCliente);
        Task<string> ObterEnderecoCliente(int idCliente);
        Task AdicionarCliente(string documento, string nome, string endereco);
        Task AtualizarCliente(int idCliente, string documento, string nome, string endereco);
        Task RemoverCliente(int idCliente);
        Task <IEnumerable<Cliente>> ObterTodosClientes();


    }
}
