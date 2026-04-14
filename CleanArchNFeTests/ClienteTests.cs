using System;
using CleanArchNFeDomain.Entities;
using CleanArchNF_eDomain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchNFeTests
{
    public class ClienteTests
    {
        [Fact(DisplayName = "Deve criar um cliente com dados válidos")]
        public void CreateCliente_ValidData_ShouldCreateCliente()
        {
            Action action = () => new Cliente("ZTdocumento", "Nome Do Cliente", "Endereço");

            action.Should()
                .NotThrow<NFeExceptionValidation>();
        }
        [Fact(DisplayName = "Documento com Dados Nulos")]
        public void CreateCliente_EmptyDocument_ShouldThrowDomainException()
        {
            Action action = () => new Cliente("", "Nome Do Cliente", "Endereco");

            action.Should()
                .Throw<NFeExceptionValidation>();
        }

        [Fact(DisplayName = "Documento muito Curto")]
        public void CreateCliente_WithShortDocument_ShouldThrowException()
        {
            Action action = () => new Cliente("A", "Nome do Cliente", "Endereço");

            action.Should()
                .Throw<NFeExceptionValidation>();
        }

        [Fact(DisplayName = "Documento muito Longo")]
        public void CreateCliente_WithLongDocument_ShouldThrowException()
        {
            Action action = () => new Cliente(
                "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890",
                "Nome do Cliente",
                "Endereço");

            action.Should()
                .Throw<NFeExceptionValidation>();
        }

        [Fact(DisplayName = "Nome do Cliente com Dados Nulos")]
        public void CreateCliente_EmptyName_ShouldThrowDomainException()
        {
            Action action = () => new Cliente("Documento", "", "Endereço");

            action.Should()
                .Throw<NFeExceptionValidation>();
        }

        [Fact(DisplayName = "Nome do Cliente muito Curto")]
        public void CreateCliente_WithShortName_ShouldThrowException()
        {
            Action action = () => new Cliente("Documento", "A", "Endereço");

            action.Should()
                .Throw<NFeExceptionValidation>();
        }

        [Fact(DisplayName = "Nome do Cliente muito Longo")]
        public void CreateCliente_WithLongName_ShouldThrowException()
        {
            Action action = () => new Cliente(
                "Documento",
                "Nome do Cliente com mais de 100 caracteres Nome do Cliente com mais de 100 caracteres Nome do Cliente com mais de 100 caracteres Nome do Cliente com mais de 100 caracteres",
                "Endereço");

            action.Should()
                .Throw<NFeExceptionValidation>();
        }

        [Fact(DisplayName = "Endereço do Cliente com Dados Nulos")]
        public void CreateCliente_EmptyAddress_ShouldThrowDomainException()
        {
            Action action = () => new Cliente("Documento", "Nome Do Cliente", "");

            action.Should()
                .Throw<NFeExceptionValidation>();
        }

        [Fact(DisplayName = "Endereço do Cliente muito Curto")]
        public void CreateCliente_WithShortAddress_ShouldThrowException()
        {
            Action action = () => new Cliente("Documento", "Nome do Cliente", "A");

            action.Should()
                .Throw<NFeExceptionValidation>();
        }

        [Fact(DisplayName = "Endereço do Cliente muito Longo")]
        public void CreateCliente_WithLongAddress_ShouldThrowException()
        {
            Action action = () => new Cliente(
                "Documento",
                "Nome do Cliente",
                "Nome do Cliente com mais de 100 caracteres Nome do Cliente com mais de 100 caracteres Nome do Cliente com mais de 100 caracteres Nome do Cliente com mais de 100 caracteres");

            action.Should()
                .Throw<NFeExceptionValidation>();
        }

    }
}