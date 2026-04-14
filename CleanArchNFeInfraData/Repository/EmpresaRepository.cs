using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNFeDomain.Entities;
using CleanArchNF_eDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchNFeInfraData.Context;

namespace CleanArchNFeInfraData.Repository
{
    public class EmpresaRepository : IEmpresa, CleanArchNF_eDomain.Interfaces.IEmpresaRepository
    {
        ApplicationDbContext _empresaContext;
        public EmpresaRepository(ApplicationDbContext context)
        {
            _empresaContext = context;
        }
        public async Task AdicionarEmpresa(string documento, string nome, string endereco)
        {
            var empresa = new Empresa(documento, nome, endereco);
            await AdicionarEmpresa(empresa);
        }

        public async Task AdicionarEmpresa(CleanArchNFeDomain.Entities.Empresa empresa)
        {
            if (empresa == null) throw new ArgumentNullException(nameof(empresa));
            await _empresaContext.AddAsync(empresa);
            await _empresaContext.SaveChangesAsync();
        }

        public async Task AtualizarEmpresa(int idEmpresa, string documento, string nome, string endereco)
        {
            var empresa = await _empresaContext.Empresas.FindAsync(idEmpresa);
            if (empresa == null) throw new Exception("Empresa não encontrada");

            empresa.Documento = documento;
            empresa.Nome = nome;
            empresa.Endereco = endereco;

            _empresaContext.Empresas.Update(empresa);
            await _empresaContext.SaveChangesAsync();
        }

        public async Task AtualizarEmpresa(CleanArchNFeDomain.Entities.Empresa empresa)
        {
            if (empresa == null) throw new ArgumentNullException(nameof(empresa));
            _empresaContext.Empresas.Update(empresa);
            await _empresaContext.SaveChangesAsync();
        }

        public async Task<Empresa> ObterEmpresaPorId(int idEmpresa)
        {
            return await _empresaContext.Empresas.FindAsync(idEmpresa);
        }

        public async Task<List<Empresa>> ObterEmpresas()
        {
            return await _empresaContext.Empresas.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> ObterEmpresasPorNome(string nome)
        {
            return await _empresaContext.Empresas
                .Where(e => e.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task<string> ObterDocumentoEmpresa(int idEmpresa)
        {
            return await _empresaContext.Empresas
                .Where(e => e.Id == idEmpresa)
                .Select(e => e.Documento)
                .FirstOrDefaultAsync();
        }

        public async Task<string> ObterEnderecoEmpresa(int idEmpresa)
        {
            return await _empresaContext.Empresas
                .Where(e => e.Id == idEmpresa)
                .Select(e => e.Endereco)
                .FirstOrDefaultAsync();
        }

        public async Task<string> ObterNomeEmpresa(int idEmpresa)
        {
            return await _empresaContext.Empresas
                .Where(e => e.Id == idEmpresa)
                .Select(e => e.Nome)
                .FirstOrDefaultAsync();
        }

        public async Task RemoverEmpresa(int idEmpresa)
        {
            var empresa = await _empresaContext.Empresas.FindAsync(idEmpresa);

            if (empresa == null)
                throw new Exception("Empresa não encontrada");

            _empresaContext.Empresas.Remove(empresa);
            await _empresaContext.SaveChangesAsync();
        }
    }
}
