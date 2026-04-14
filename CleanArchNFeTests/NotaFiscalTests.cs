using System;
using System.Collections.Generic;
using CleanArchNFeDomain.Entities;
using CleanArchNF_eDomain.Enums;
using CleanArchNF_eDomain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchNFeTests
{
    public class NotaFiscalTests
    {
        [Fact(DisplayName = "Deve criar uma nota fiscal com dados válidos")]
        public void CreateNotaFiscal_ValidData_ShouldCreateNotaFiscal()
        {
            var cliente = new Cliente("DocumentClient", "Nome Do Cliente", "Endereço");
            var empresa = new Empresa("12.345.678/0001-95", "EmpresaLTDA", "Endereço da Empresa");
            var itens = new List<ItemNotaFiscal>
            {
                new ItemNotaFiscal(1, "Produto 1", 2, 10.00m, 2.00m),
                new ItemNotaFiscal(2, "Produto 2", 1, 20.00m, 4.00m),
            };
            var status = StatusNotaFiscal.pendente;
            Action action = () => new NotaFiscal(
                1,
                1,
                cliente,
                empresa,
                itens,
                40.00m,
                6.00m,
                status,
                dataEmissao: DateTime.Now
                );
            action.Should().NotThrow<NFeExceptionValidation>();
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um numero valido")]
        public void CreateNotaFiscal_InvalidNumero_ShouldThrowException()
        {
            var cliente = new Cliente("DocumentClient", "Nome Do Cliente", "Endereço");
            var empresa = new Empresa("12.345.678/0001-95", "EmpresaLTDA", "Endereço da Empresa");
            var itens = new List<ItemNotaFiscal>
            {
                new ItemNotaFiscal(1, "Produto 1", 2, 10.00m, 2.00m),
                new ItemNotaFiscal(2, "Produto 2", 1, 20.00m, 4.00m),
            };
            var status = StatusNotaFiscal.pendente;
            Action action = () => new NotaFiscal(
                0,
                1,
                cliente,
                empresa,
                itens,
                40.00m,
                6.00m,
                status,
                dataEmissao: DateTime.Now
                );
            action.Should().Throw<NFeExceptionValidation>()
                .WithMessage("O numero da nota fiscal é obrigatorio e deve ser maior que zero");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar uma serie valida ")]
        public void CreateNotaFiscal_InvalidSerie_ShouldThrowException()
        {
            var cliente = new Cliente("DocumentClient", "Nome Do Cliente", "Endereço");
            var empresa = new Empresa("12.345.678/0001-95", "EmpresaLTDA", "Endereço da Empresa");
            var itens = new List<ItemNotaFiscal>
            {
                new ItemNotaFiscal(1, "Produto 1", 2, 10.00m, 2.00m),
                new ItemNotaFiscal(2, "Produto 2", 1, 20.00m, 4.00m),
            };
            var status = StatusNotaFiscal.pendente;
            Action action = () => new NotaFiscal(
                1,
                0,
                cliente,
                empresa,
                itens,
                40.00m,
                6.00m,
                status,
                dataEmissao: DateTime.Now
                );
            action.Should().Throw<NFeExceptionValidation>()
                .WithMessage("A serie da nota fiscal é obrigatoria e deve ser maior que zero");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um cliente nulo")]
        public void CreateNotaFiscal_NullCliente_ShouldThrowException()
        {
            var empresa = new Empresa("12.345.678/0001-95", "EmpresaLTDA", "Endereço da Empresa");
            var itens = new List<ItemNotaFiscal>
                {
                    new ItemNotaFiscal(1, "Produto 1", 2, 10.00m, 2.00m),
                    new ItemNotaFiscal(2, "Produto 2", 1, 20.00m, 4.00m),
                };
            var status = StatusNotaFiscal.pendente;
            Action action = () => new NotaFiscal(
                1,
                1,
                null,
                empresa,
                itens,
                40.00m,
                6.00m,
                status,
                dataEmissao: DateTime.Now
                );
            action.Should().Throw<NFeExceptionValidation>()
                .WithMessage("O cliente da nota fiscal é obrigatorio");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um Item Nota Fiscal nulo")]
        public void CreateNotaFiscal_NullItemNotaFiscal_ShouldThrowException()
        {
            var cliente = new Cliente("DocumentClient", "Nome Do Cliente", "Endereço");
            var empresa = new Empresa("12.345.678/0001-95", "EmpresaLTDA", "Endereço da Empresa");
            var status = StatusNotaFiscal.pendente;
            Action action = () => new NotaFiscal(
                1,
                1,
                cliente,
                empresa,
                null,
                40.00m,
                6.00m,
                status,
                dataEmissao: DateTime.Now
                );
            action.Should().Throw<NFeExceptionValidation>()
                .WithMessage("A nota fiscal deve conter pelo menos um item");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um total inválido")]
        public void CreateNotaFiscal_InvalidTotal_ShouldThrowException()
        {
            var cliente = new Cliente("DocumentClient", "Nome Do Cliente", "Endereço");
            var empresa = new Empresa("12.345.678/0001-95", "EmpresaLTDA", "Endereço da Empresa");
            var itens = new List<ItemNotaFiscal>
            {
                new ItemNotaFiscal(1, "Produto 1", 2, 10.00m, 2.00m),
                new ItemNotaFiscal(2, "Produto 2", 1, 20.00m, 4.00m),
            };
            var status = StatusNotaFiscal.pendente;
            Action action = () => new NotaFiscal(
                1,
                1,
                cliente,
                empresa,
                itens,
                -40.00m,
                6.00m,
                status,
                dataEmissao: DateTime.Now
                );
            action.Should().Throw<NFeExceptionValidation>()
                .WithMessage("O total da nota fiscal é obrigatorio e deve ser maior que zero");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um valor de impostos inválido")]
        public void CreateNotaFiscal_InvalidImpostos_ShouldThrowException()
        {
            var cliente = new Cliente("DocumentClient", "Nome Do Cliente", "Endereço");
            var empresa = new Empresa("12.345.678/0001-95", "EmpresaLTDA", "Endereço da Empresa");
            var itens = new List<ItemNotaFiscal>
                {
                    new ItemNotaFiscal(1, "Produto 1", 2, 10.00m, 2.00m),
                    new ItemNotaFiscal(2, "Produto 2", 1, 20.00m, 4.00m),
                };
            var status = StatusNotaFiscal.pendente;
            Action action = () => new NotaFiscal(
                1,
                1,
                cliente,
                empresa,
                itens,
                40.00m,
                -6.00m,
                status,
                dataEmissao: DateTime.Now
                );
            action.Should().Throw<NFeExceptionValidation>()
                .WithMessage("O valor dos impostos da nota fiscal é obrigatorio e deve ser maior ou igual a zero");

        }
        [Fact(DisplayName = "Deve lançar exceção ao criar uma data de emissão futura")]
        public void CreateNotaFiscal_FutureDataEmissao_ShouldThrowException()
        {
            var cliente = new Cliente("DocumentClient", "Nome Do Cliente", "Endereço");
            var empresa = new Empresa("12.345.678/0001-95", "EmpresaLTDA", "Endereço da Empresa");
            var itens = new List<ItemNotaFiscal>
                {
                    new ItemNotaFiscal(1, "Produto 1", 2, 10.00m, 2.00m),
                    new ItemNotaFiscal(2, "Produto 2", 1, 20.00m, 4.00m),
                };
            var status = StatusNotaFiscal.pendente;
            Action action = () => new NotaFiscal(
                1,
                1,
                cliente,
                empresa,
                itens,
                40.00m,
                6.00m,
                status,
                dataEmissao: DateTime.Now.AddDays(1)
                );
            action.Should().Throw<NFeExceptionValidation>()
                .WithMessage("A data de emissão da nota fiscal não pode ser futura");
        }
        [Fact(DisplayName = "Deve lançar exceção ao criar um status inválido")]
        public void CreateNotaFiscal_InvalidStatus_ShouldThrowException()
        {
            var cliente = new Cliente("DocumentClient", "Nome Do Cliente", "Endereço");
            var empresa = new Empresa("12.345.678/0001-95", "EmpresaLTDA", "Endereço da Empresa");
            var itens = new List<ItemNotaFiscal>
                {
                    new ItemNotaFiscal(1, "Produto 1", 2, 10.00m, 2.00m),
                    new ItemNotaFiscal(2, "Produto 2", 1, 20.00m, 4.00m),
                };
            Action action = () => new NotaFiscal(
                1,
                1,
                cliente,
                empresa,
                itens,
                40.00m,
                6.00m,
                (StatusNotaFiscal)999,
                dataEmissao: DateTime.Now
                );
            action.Should().Throw<NFeExceptionValidation>()
                .WithMessage("Status da nota fiscal é inválido");
        }
    }
}
