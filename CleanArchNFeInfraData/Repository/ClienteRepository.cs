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
    public class ClienteRepository : ICliente
    {
        ApplicationDbContext _clienteContext;    
        public ClienteRepository(ApplicationDbContext context)
        {
            _clienteContext = context;
        }

        public async Task AdicionarCliente(string documento, string nome, string endereco)
        {
            _clienteContext.Clientes.Add(new Cliente(documento, nome, endereco));
        }

        public async Task AtualizarCliente(int idCliente, string documento, string nome, string endereco)
        {
            _clienteContext.Clientes.Update(new Cliente(documento, nome, endereco) { Id = idCliente });
        }

        public async Task<Cliente> ObterClientePorId(int idCliente)
        {
            return await _clienteContext.Clientes.FirstOrDefaultAsync(c => c.Id == idCliente);
        }

        public async Task<IEnumerable<Cliente>> ObterClientesPorNome(string nome)
        {
            return await _clienteContext.Clientes
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task<string> ObterDocumentoCliente(int idCliente)
        {
            return await _clienteContext.Clientes
                .Where(c => c.Id == idCliente)
                .Select(c => c.Documento)
                .FirstOrDefaultAsync();
        }

        public async Task<string> ObterEnderecoCliente(int idCliente)
        {
            return await _clienteContext.Clientes
                .Where(c => c.Id == idCliente)
                .Select(c => c.Endereco)
                .FirstOrDefaultAsync();
        }

        public async Task<string> ObterNomeCliente(int idCliente)
        {
            return await _clienteContext.Clientes
                .Where(c => c.Id == idCliente)
                .Select(c => c.Nome)
                .FirstOrDefaultAsync();
        }

        public async Task RemoverCliente(int idCliente)
        {
            var cliente = await _clienteContext.Clientes.FirstOrDefaultAsync(c => c.Id == idCliente);
            if (cliente != null)
            {
                _clienteContext.Clientes.Remove(cliente);
                await _clienteContext.SaveChangesAsync();
            }
        }
    }
}
