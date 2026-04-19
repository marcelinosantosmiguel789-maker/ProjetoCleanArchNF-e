using Microsoft.AspNetCore.Mvc;
using CleanArchNFeApplication.Interfaces;
using CleanArchNFeApplication.DTOs;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace CleanArchWebUINFe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INotaFiscalService _notaService;
        private readonly IItemNotaFiscalService _itemService;

        public NotaFiscalController(INotaFiscalService notaService, IItemNotaFiscalService itemService)
        {
            _notaService = notaService;
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotaFiscalDTO dto)
        {
            if (dto is null) return BadRequest("Dados da nota inválidos");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            // Here assume there is a service method to create NotaFiscal; use ObterNumero as placeholder
            // If your service has Create method, replace accordingly.
            // For now return 201 with location to Get
            // TODO: replace with real creation
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nota = await _notaService.ObterItensNotaAsync(id); // returns items but used to validate existence
            if (nota == null) return NotFound();

            // Build a simple response using service methods
            var empresa = await _notaService.ObterEmpresaNotaAsync(id);
            var cliente = await _notaService.ObterClienteNotaAsync(id);
            var itens = await _notaService.ObterItensNotaAsync(id);
            var response = new
            {
                Id = id,
                Empresa = empresa,
                Cliente = cliente,
                Itens = itens,
                Numero = await _notaService.ObterNumeroNotaAsync(id),
                Serie = await _notaService.ObterSerieNotaAsync(id),
                Total = await _notaService.ObterTotalNotaAsync(id),
                Impostos = await _notaService.ObterImpostosNotaAsync(id),
                Status = await _notaService.ObterStatusNotaAsync(id),
                DataEmissao = await _notaService.ObterDataEmissaoNotaAsync(id)
            };

            return Ok(response);
        }

        [HttpPost("{id:int}/emitir")]
        public async Task<IActionResult> Emitir(int id)
        {
            // Business rules handled in domain/service
            // Assume service has method to update status to emit (using AtualizarStatusNotaAsync)
            await _notaService.AtualizarStatusNotaAsync(id, CleanArchNF_eDomain.Enums.StatusNotaFiscal.Emitida);
            return Ok();
        }

        [HttpPost("{id:int}/cancelar")]
        public async Task<IActionResult> Cancelar(int id)
        {
            await _notaService.AtualizarStatusNotaAsync(id, CleanArchNF_eDomain.Enums.StatusNotaFiscal.Cancelada);
            return Ok();
        }

        [HttpPost("{id:int}/itens")]
        public async Task<IActionResult> AddItem(int id, [FromBody] ItemNotaFiscalDTO item)
        {
            if (item is null) return BadRequest("Item inválido");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            await _itemService.AdicionarItemNotaAsync(id, item);
            return CreatedAtAction(nameof(GetItems), new { id }, null);
        }

        [HttpGet("{id:int}/itens")]
        public async Task<IActionResult> GetItems(int id)
        {
            var itens = await _itemService.ObterItensNotaAsync(id);
            return Ok(itens);
        }

        [HttpDelete("{id:int}/itens/{produtoId:int}")]
        public async Task<IActionResult> DeleteItem(int id, int produtoId)
        {
            await _itemService.RemoverItemNotaAsync(id, produtoId);
            return Ok();
        }
    }
}
