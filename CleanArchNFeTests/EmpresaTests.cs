using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Entities;
using CleanArchNF_eDomain.Validation;
using FluentAssertions;

namespace CleanArchNFeTests
{
    public class EmpresaTests
    {
        [Fact(DisplayName = "Deve criar uma empresa com dados válidos")]
        public void CreateEmpresa_ValidData_ShouldCreateEmpresa()
        {
            Action action = () => new Empresa("00.000.000/0000-00", "Razão Social da Empresa", "Endereço da Empresa");
            action.Should()
                .NotThrow<NFeExceptionValidation>();
        }
        [Fact(DisplayName = "CNPJ com Dados Nulos")]
        public void CreateEmpresa_EmptyCnpj_ShouldThrowDomainException()
        {
            Action action = () => new Empresa("", "Razão Social da Empresa", "Endereço da Empresa");
            action.Should()
                .Throw<NFeExceptionValidation>();
        }
        [Fact(DisplayName = "CNPJ muito Curto")]
        public void CreateEmpresa_WithShortCnpj_ShouldThrowException()
        {
            Action action = () => new Empresa("123", "Razão Social da Empresa", "Endereço da Empresa");
            action.Should()
                .Throw<NFeExceptionValidation>();
        }
        [Fact(DisplayName = "CNPJ muito Longo")]
        public void CreateEmpresa_WithLongCnpj_ShouldThrowException()
        {
            Action action = () => new Empresa("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", "Razão Social da Empresa", "Endereço da Empresa");
            action.Should()
                .Throw<NFeExceptionValidation>();
        }
        [Fact(DisplayName = "Razão Social com Dados Nulos")]
        public void CreateEmpresa_EmptyRazaoSocial_ShouldThrowDomainException()
        {
            Action action = () => new Empresa("00.000.000/0000-00", "", "Endereço da Empresa");
            action.Should()
                .Throw<NFeExceptionValidation>();
        }
        [Fact(DisplayName = "Razão Social muito Curta")]
        public void CreateEmpresa_WithShortRazaoSocial_ShouldThrowException()
        {
            Action action = () => new Empresa("00.000.000/0000-00", "A", "Endereço da Empresa");
            action.Should()
                .Throw<NFeExceptionValidation>();
        }
        [Fact(DisplayName = "Razão Social muito Longa")]
        public void CreateEmpresa_WithLongRazaoSocial_ShouldThrowException()
        {
            Action action = () => new Empresa("00.000.000/0000-00", "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", "Endereço da Empresa");
            action.Should()
                .Throw<NFeExceptionValidation>();
        }
         [Fact(DisplayName = "Endereço com Dados Nulos")]
         public void CreateEmpresa_EmptyEndereco_ShouldThrowDomainException()
            {
                Action action = () => new Empresa("00.000.000/0000-00", "Razão Social da Empresa", "");
                action.Should()
                    .Throw<NFeExceptionValidation>();
        }
    }
}
