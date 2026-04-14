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
    public class ClienteRepository : ICliente
    {
        ApplicationDbContext _clienteContext;
        public ClienteRepository(ApplicationDbContext context)
        {
            _clienteContext = context;
        }

        public async Task AdicionarCliente(string documento, string nome, string endereco)
        {
            var cliente = new Cliente(documento, nome, endereco);

            if (cliente == null)
            {
                throw new Exception("Erro ao criar cliente");
            }
            await _clienteContext.AddAsync(cliente);
        }

        public async Task AtualizarCliente(int idCliente, string documento, string nome, string endereco)
        {
            var cliente = await _clienteContext.Clientes.FindAsync(idCliente);

            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            cliente.Atualizar(documento, nome, endereco); // ideal ter método na entidade

            _clienteContext.Clientes.Update(cliente);
            await _clienteContext.SaveChangesAsync();
        }

        public async Task<Cliente> ObterClientePorId(int idCliente)
        {
            return await _clienteContext.Clientes.FindAsync(idCliente);
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
            var cliente = await _clienteContext.Clientes.FindAsync(idCliente);

            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            _clienteContext.Clientes.Remove(cliente);
            await _clienteContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Cliente>> ObterTodosClientes()
        {
            return await _clienteContext.Clientes.ToListAsync();
        }
    }
}

