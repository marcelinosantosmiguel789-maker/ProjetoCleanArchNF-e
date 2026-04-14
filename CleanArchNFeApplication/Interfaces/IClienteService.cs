using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNFeApplication.DTOs;
using CleanArchNFeDomain.Entities;

namespace CleanArchNFeApplication.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ObterTodosAsync();
        Task<ClienteDTO> GetByIdAsync(int id);
        Task Add(string nome, string endereco, string documento);    
        Task Update(ClienteDTO clienteDTO);
        Task DeleteByIdAsync(int id);
    }
}
