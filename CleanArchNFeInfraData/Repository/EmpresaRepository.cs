using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Entities;
using CleanArchNF_eDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchNFeInfraData.Context;

namespace CleanArchNFeInfraData.Repository
{
    public class EmpresaRepository : IEmpresa
    {
        ApplicationDbContext _empresaContext;
        public EmpresaRepository(ApplicationDbContext context)
        {
            _empresaContext = context;
        }

        public async Task AdicionarEmpresa(string documento, string nome, string endereco)
        {
            _empresaContext.Empresas.Add(new Empresa(documento, nome, endereco));
            await _empresaContext.SaveChangesAsync();
        }

        public async Task AtualizarEmpresa(int idEmpresa, string documento, string nome, string endereco)
        {
            _empresaContext.Empresas.Update(new Empresa(documento, nome, endereco) { Id = idEmpresa });
            await _empresaContext.SaveChangesAsync();
        }

        public async Task<string> ObterDocumentoEmpresa(int idEmpresa)
        {
            return await _empresaContext.Empresas
                .Where(e => e.Id == idEmpresa)
                .Select(e => e.Cnpj)
                .FirstOrDefaultAsync();
        }

        public async Task<Empresa> ObterEmpresaPorId(int idEmpresa)
        {
            return await _empresaContext.Empresas
                .Where(e => e.Id == idEmpresa)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Empresa>> ObterEmpresas()
        {
            return await _empresaContext.Empresas.ToListAsync();
        }

        public async Task<IEnumerable<Empresa>> ObterEmpresasPorNome(string nome)
        {
            return await _empresaContext.Empresas.Where(e => e.RazaoSocial.Contains(nome))
                .ToListAsync();

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
                .Select(e => e.RazaoSocial)
                .FirstOrDefaultAsync();
        }

        public async Task RemoverEmpresa(int idEmpresa)
        {
           var empresa = await _empresaContext.Empresas.FirstOrDefaultAsync(e => e.Id == idEmpresa);
            if (empresa != null)
            {
                _empresaContext.Empresas.Remove(empresa);
                await _empresaContext.SaveChangesAsync();
            }
        }
    }
}
