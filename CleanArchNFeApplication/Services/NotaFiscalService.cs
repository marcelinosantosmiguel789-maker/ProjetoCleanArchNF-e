using AutoMapper;
using CleanArchNF_eDomain.Enums;
using CleanArchNF_eDomain.Interfaces;
using CleanArchNFeApplication.DTOs;
using CleanArchNFeApplication.Interfaces;
using CleanArchNFeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchNFeApplication.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IMapper _mapper;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository, IMapper mapper)
        {
            _notaFiscalRepository = notaFiscalRepository ?? throw new ArgumentNullException(nameof(notaFiscalRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AdicionarItemNotaAsync(int idNotaFiscal, ItemNotaFiscalDTO itemDto)
        {
            if (itemDto is null) throw new ArgumentNullException(nameof(itemDto));

            var itemEntity = _mapper.Map<ItemNotaFiscal>(itemDto);
            await _notaFiscalRepository.AdicionarItemNotaAsync(idNotaFiscal, itemEntity);
        }

        public async Task AtualizarClienteNotaAsync(int idNotaFiscal, ClienteDTO clienteDto)
        {
            if (clienteDto is null) throw new ArgumentNullException(nameof(clienteDto));

            var clienteEntity = _mapper.Map<Cliente>(clienteDto);
            await _notaFiscalRepository.AtualizarClienteNotaAsync(idNotaFiscal, clienteEntity);
        }

        public async Task AtualizarEmpresaNotaAsync(int idNotaFiscal, EmpresaDTO empresaDto)
        {
            if (empresaDto is null) throw new ArgumentNullException(nameof(empresaDto));

            var empresaEntity = _mapper.Map<Empresa>(empresaDto);
            await _notaFiscalRepository.AtualizarEmpresaNotaAsync(idNotaFiscal, empresaEntity);
        }

        public async Task AtualizarItemNotaAsync(int idNotaFiscal, ItemNotaFiscalDTO itemDto)
        {
            if (itemDto is null) throw new ArgumentNullException(nameof(itemDto));

            var itemEntity = _mapper.Map<ItemNotaFiscal>(itemDto);
            await _notaFiscalRepository.AtualizarItemNotaAsync(idNotaFiscal, itemEntity);
        }

        public async Task AtualizarNumeroAsync(int idNotaFiscal, int numero)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            await _notaFiscalRepository.AtualizarNumeroAsync(idNotaFiscal, numero);
        }

        public async Task AtualizarSerieAsync(int idNotaFiscal, int serie)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            await _notaFiscalRepository.AtualizarSerieAsync(idNotaFiscal, serie);
        }

        public async Task AtualizarStatusNotaAsync(int idNotaFiscal, StatusNotaFiscal status)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            await _notaFiscalRepository.AtualizarStatusNotaAsync(idNotaFiscal, status);
        }

        public async Task<ClienteDTO> ObterClienteNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            return _mapper.Map<ClienteDTO>(nota.Cliente);
        }

        public async Task<DateTime> ObterDataEmissaoNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            return nota.DataEmissao;
        }

        public async Task<EmpresaDTO> ObterEmpresaNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            return _mapper.Map<EmpresaDTO>(nota.Empresa);
        }

        public async Task<decimal> ObterImpostosNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            return nota.Itens?.Sum(i => i.ValorImpostos) ?? 0m;
        }

        public async Task<IEnumerable<ItemNotaFiscalDTO>> ObterItensNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            return _mapper.Map<IEnumerable<ItemNotaFiscalDTO>>(nota.Itens ?? Enumerable.Empty<ItemNotaFiscal>());
        }

        public async Task<int> ObterNumeroNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            return nota.Numero;
        }

        public async Task<int> ObterSerieNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            return nota.Serie;
        }

        public async Task<StatusNotaFiscal> ObterStatusNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            return nota.Status;
        }

        public async Task<decimal> ObterTotalNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            return nota.Itens?.Sum(i => i.Total) ?? 0m;
        }

        public async Task RemoverItemNotaAsync(int idNotaFiscal, int idProduto)
        {
            var nota = await _notaFiscalRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            await _notaFiscalRepository.RemoverItemNotaAsync(idNotaFiscal, idProduto);
        }
    }
}
