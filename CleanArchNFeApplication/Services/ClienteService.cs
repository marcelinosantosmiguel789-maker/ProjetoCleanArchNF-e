using CleanArchNFeApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNFeApplication.DTOs;
using AutoMapper;
using CleanArchNFeDomain.Entities;
using CleanArchNF_eDomain.Interfaces;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace CleanArchNFeApplication.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly ICliente _clienteRepository;

        public async Task Add(string nome, string endereco, string documento)
        {
            var cliente = new Cliente
            {
                Nome = nome,
                Endereco = endereco,
                Documento = documento
            };

            await _clienteRepository.AdicionarCliente(
                cliente.Documento,
                cliente.Nome,
                cliente.Endereco
            );
        }

        public async Task DeleteByIdAsync(int id)
        {
            var cliente = new Cliente
            {
                Id = id
            };
            await _clienteRepository.RemoverCliente(cliente.Id);
        }

        public async Task<ClienteDTO> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.ObterClientePorId(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> ObterTodosAsync()
        {
            var clientes = await _clienteRepository.ObterTodosClientes();
            return clientes.Select(cliente => _mapper.Map<ClienteDTO>(cliente));
        }

        public async Task Update(ClienteDTO clienteDTO)
        {
            var cliente = await _clienteRepository.ObterClientePorId(clienteDTO.Id);

            if (cliente == null)
                throw new Exception("Cliente não encontrado");
            cliente.Id = clienteDTO.Id;
            cliente.Nome = clienteDTO.nome;
            cliente.Endereco = clienteDTO.endereco;
            cliente.Documento = clienteDTO.documento;

            await _clienteRepository.AtualizarCliente(
                cliente.Id,
                cliente.Documento,
                cliente.Nome,
                cliente.Endereco
            );
        }
    }
}
