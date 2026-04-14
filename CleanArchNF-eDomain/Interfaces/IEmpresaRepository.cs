using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNFeDomain.Entities;

namespace CleanArchNF_eDomain.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> ObterEmpresas();
        Task<Empresa> ObterEmpresaPorId(int idEmpresa);
        Task<IEnumerable<Empresa>> ObterEmpresasPorNome(string nome);
        Task<string> ObterNomeEmpresa(int idEmpresa);
        Task<string> ObterDocumentoEmpresa(int idEmpresa);
        Task<string> ObterEnderecoEmpresa(int idEmpresa);
        Task AdicionarEmpresa(Empresa empresa);
        Task AtualizarEmpresa(Empresa empresa);
        Task RemoverEmpresa(int idEmpresa);
    }
}
