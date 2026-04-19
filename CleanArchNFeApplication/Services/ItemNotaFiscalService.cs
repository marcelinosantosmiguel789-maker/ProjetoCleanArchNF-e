using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchNF_eDomain.Enums;
using CleanArchNF_eDomain.Interfaces;
using CleanArchNFeApplication.DTOs;
using CleanArchNFeApplication.Interfaces;
using CleanArchNFeDomain.Entities;

namespace CleanArchNFeApplication.Services
{
    public class ItemNotaFiscalService : IItemNotaFiscalService
    {
        private readonly INotaFiscalRepository _notaRepository;
        private readonly IMapper _mapper;

        public ItemNotaFiscalService(INotaFiscalRepository notaRepository, IMapper mapper)
        {
            _notaRepository = notaRepository ?? throw new ArgumentNullException(nameof(notaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AdicionarItemNotaAsync(int idNotaFiscal, ItemNotaFiscalDTO itemDto)
        {
            if (itemDto is null) throw new ArgumentNullException(nameof(itemDto));

            var nota = await _notaRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            var itemEntity = _mapper.Map<ItemNotaFiscal>(itemDto);
            nota.AdicionarItem(itemEntity);
            await _notaRepository.SalvarNotaAsync(nota);
        }

        public async Task<IEnumerable<ItemNotaFiscalDTO>> ObterItensNotaAsync(int idNotaFiscal)
        {
            var nota = await _notaRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            var dtos = _mapper.Map<IEnumerable<ItemNotaFiscalDTO>>(nota.Itens ?? Enumerable.Empty<ItemNotaFiscal>());
            return dtos;
        }

        public async Task RemoverItemNotaAsync(int idNotaFiscal, int idProduto)
        {
            var nota = await _notaRepository.ObterNotaPorIdAsync(idNotaFiscal);
            if (nota == null) throw new KeyNotFoundException("Nota fiscal não encontrada");

            nota.RemoverItemPorProduto(idProduto);
            await _notaRepository.SalvarNotaAsync(nota);
        }

        public Task<List<ItemNotaFiscal>> ObterItensNotaFiscal(int idNotaFiscal) => throw new NotImplementedException();
        public Task<IEnumerable<ItemNotaFiscal>> ObterTodosItensNotaFiscal() => throw new NotImplementedException();
        public Task<IEnumerable<ItemNotaFiscal>> ObterItensNotaFiscalPorProduto(int idProduto) => throw new NotImplementedException();
        public Task AdicionarItemNotaFiscal(int idProduto, int quantidade, decimal valorUnitario) => throw new NotImplementedException();
        public Task<decimal> CalcularValorTotalItemNotaFiscal(int idProduto) => throw new NotImplementedException();
        public Task<decimal> CalcularTotalItemNotaFiscal(int idProduto) => throw new NotImplementedException();
        public Task AtualizarItemNotaFiscal(int idProduto, int quantidade, decimal valorUnitario) => throw new NotImplementedException();
        public Task RemoverItemNotaFiscal(int idProduto) => throw new NotImplementedException();
    }
}
