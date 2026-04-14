using CleanArchNFeApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchNFeApplication.Interfaces
{
    public interface IEmpresaService
    {
        Task<List<EmpresaDTO>> ObterEmpresas();
        Task<EmpresaDTO> ObterEmpresaPorId(int idEmpresa);
        Task<IEnumerable<EmpresaDTO>> ObterEmpresasPorNome(string nome);
        Task<string> ObterNomeEmpresa(int idEmpresa);
        Task<string> ObterDocumentoEmpresa(int idEmpresa);
        Task<string> ObterEnderecoEmpresa(int idEmpresa);
        Task AdicionarEmpresa(EmpresaDTO empresaDto);
        Task AtualizarEmpresa(int idEmpresa, EmpresaDTO empresaDto);
        Task RemoverEmpresa(int idEmpresa);
    }
}
