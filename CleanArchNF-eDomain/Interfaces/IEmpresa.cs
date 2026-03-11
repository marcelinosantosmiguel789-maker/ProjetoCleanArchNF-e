using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Entities;

namespace CleanArchNF_eDomain.Interfaces
{
    public interface IEmpresa
    {
        Task<List<Empresa>> ObterEmpresas();
        Task<Empresa> ObterEmpresaPorId(int idEmpresa);
        Task<IEnumerable<Empresa>> ObterEmpresasPorNome(string nome);
        Task<string> ObterNomeEmpresa(int idEmpresa);
        Task<string> ObterDocumentoEmpresa(int idEmpresa);
        Task<string> ObterEnderecoEmpresa(int idEmpresa);
        Task AdicionarEmpresa(string documento, string nome, string endereco);
        Task AtualizarEmpresa(int idEmpresa, string documento, string nome, string endereco);
        Task RemoverEmpresa(int idEmpresa);
    }
}
