using AutoMapper;
using CleanArchNF_eDomain.Interfaces;
using CleanArchNFeApplication.DTOs;
using CleanArchNFeApplication.Interfaces;
using CleanArchNFeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchNFeApplication.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task AdicionarEmpresa(EmpresaDTO empresaDto)
        {
            if (empresaDto is null) throw new ArgumentNullException(nameof(empresaDto));

            var entity = _mapper.Map<Empresa>(empresaDto);
            await _empresaRepository.AdicionarEmpresa(entity);
        }

        public async Task AtualizarEmpresa(int idEmpresa, EmpresaDTO empresaDto)
        {
            if (empresaDto is null) throw new ArgumentNullException(nameof(empresaDto));

            var existing = await _empresaRepository.ObterEmpresaPorId(idEmpresa);
            if (existing is null) throw new KeyNotFoundException("Empresa não encontrada");

            _mapper.Map(empresaDto, existing);
            await _empresaRepository.AtualizarEmpresa(existing);
        }

        public async Task<string> ObterDocumentoEmpresa(int idEmpresa)
            => await _empresaRepository.ObterDocumentoEmpresa(idEmpresa);

        public async Task<EmpresaDTO> ObterEmpresaPorId(int idEmpresa)
        {
            var entity = await _empresaRepository.ObterEmpresaPorId(idEmpresa);
            return _mapper.Map<EmpresaDTO>(entity);
        }

        public async Task<List<EmpresaDTO>> ObterEmpresas()
        {
            var entities = await _empresaRepository.ObterEmpresas();
            return _mapper.Map<List<EmpresaDTO>>(entities);
        }

        public async Task<IEnumerable<EmpresaDTO>> ObterEmpresasPorNome(string nome)
        {
            var entities = await _empresaRepository.ObterEmpresasPorNome(nome);
            return _mapper.Map<IEnumerable<EmpresaDTO>>(entities);
        }

        public async Task<string> ObterEnderecoEmpresa(int idEmpresa)
            => await _empresaRepository.ObterEnderecoEmpresa(idEmpresa);

        public async Task<string> ObterNomeEmpresa(int idEmpresa)
            => await _empresaRepository.ObterNomeEmpresa(idEmpresa);

        public async Task RemoverEmpresa(int idEmpresa)
            => await _empresaRepository.RemoverEmpresa(idEmpresa);
    }
}
