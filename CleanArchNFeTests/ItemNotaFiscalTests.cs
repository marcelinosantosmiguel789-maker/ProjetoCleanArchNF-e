using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Validation;
using FluentAssertions;
using CleanArchNF_eDomain.Entities;

namespace CleanArchNFeTests
{
    public class ItemNotaFiscalTests
    {
        [Fact(DisplayName = "Deve criar um item de nota fiscal com dados válidos e calcular total corretamente")]
        public void CreateItemNotaFiscal_ValidData_ShouldCreateItemNotaFiscal()
        {
            var produtoId = 1;
            var descricao = "Produto de Teste";
            var quantidade = 10;
            var valorUnitario = 15.5m;
            var valorImpostos = 2m;

            var totalEsperado = quantidade * valorUnitario;

            var itemNotaFiscal = new ItemNotaFiscal(
                produtoId,
                descricao,
                quantidade,
                valorUnitario,
                valorImpostos
            );

            itemNotaFiscal.ProdutoId.Should().Be(produtoId);
            itemNotaFiscal.Descricao.Should().Be(descricao);
            itemNotaFiscal.Quantidade.Should().Be(quantidade);
            itemNotaFiscal.ValorUnitario.Should().Be(valorUnitario);
            itemNotaFiscal.Total.Should().Be(totalEsperado);
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um item de nota fiscal com produtoId inválido")]
        public void CreateItemNotaFiscal_InvalidProdutoId_ShouldThrowException()
        {
            Action action = () => new ItemNotaFiscal(0, "Produto de Teste", 10, 15.5m, 2m);
            action.Should()
                .Throw<NFeExceptionValidation>()
                .WithMessage("O Id do produto é obrigatorio e deve ser maior que zero");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um item de nota fiscal com descrição inválida")]
        public void CreateItemNotaFiscal_InvalidDescricao_ShouldThrowException()
        {
            Action action = () => new ItemNotaFiscal(1, "", 10, 15.5m, 2m);
            action.Should()
                .Throw<NFeExceptionValidation>()
                .WithMessage("A descrição do produto é obrigatoria");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um item de nota fiscal com quantidade inválida")]
        public void CreateItemNotaFiscal_InvalidQuantidade_ShouldThrowException()
        {
            Action action = () => new ItemNotaFiscal(1, "Produto de Teste", 0, 15.5m, 2m);
            action.Should()
                .Throw<NFeExceptionValidation>()
                .WithMessage("A quantidade do produto é obrigatoria e deve ser maior que zero");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um item de nota fiscal com valor unitário inválido")]
        public void CreateItemNotaFiscal_InvalidValorUnitario_ShouldThrowException()
        {
            Action action = () => new ItemNotaFiscal(1, "Produto de Teste", 10, 0m, 2m);
            action.Should()
                .Throw<NFeExceptionValidation>()
                .WithMessage("O valor unitário do produto é obrigatorio e deve ser maior que zero");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um item de nota fiscal com valor de impostos inválido")]
        public void CreateItemNotaFiscal_InvalidValorImpostos_ShouldThrowException()
        {
            Action action = () => new ItemNotaFiscal(1, "Produto de Teste", 10, 15.5m, -1m);
            action.Should()
                .Throw<NFeExceptionValidation>()
                .WithMessage("O valor dos impostos do produto deve ser maior ou igual a zero");
        }
    }
}