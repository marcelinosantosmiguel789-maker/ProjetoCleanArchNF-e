using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Validation;

namespace CleanArchNFeDomain.Entities
{
    public sealed class Empresa : Entity
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get;  set; }
        // compatibility properties used by repositories and interfaces
        public string Documento { get => Cnpj; set => Cnpj = value; }
        public string Nome { get => RazaoSocial; set => RazaoSocial = value; }
        public string Endereco { get; set; }
        public Empresa() { }

        public Empresa(string cnpj) 
        {
            ValidateCnpj(cnpj);
        }

        public Empresa(string cnpj, string razaoSocial)
        {
            ValidateCnpj(cnpj);
            ValidateRazaoSocial(razaoSocial);
        }

        public Empresa(string cnpj, string razaoSocial, string endereco)
        {
            ValidateCnpj(cnpj);
            ValidateRazaoSocial(razaoSocial);
            ValidateEndereco(endereco);
        }

        private void ValidateCnpj(string cnpj)
        {
            NFeExceptionValidation.When(string.IsNullOrEmpty(cnpj), "O CNPJ da empresa é obrigatorio");
            NFeExceptionValidation.When(cnpj.Length > 18, "O CNPJ da empresa deve conter no maximo 18 caracteres");
            NFeExceptionValidation.When(cnpj.Length < 14, "O CNPJ da empresa deve conter no minimo 14 caracteres");


            Cnpj = cnpj;
        }

        private void ValidateRazaoSocial(string razaoSocial)
        {
            NFeExceptionValidation.When(string.IsNullOrEmpty(razaoSocial), "A razão social da empresa é obrigatoria");
            NFeExceptionValidation.When(razaoSocial.Length < 3, "A razão social da empresa deve conter no minimo 3 caracteres");
            NFeExceptionValidation.When(razaoSocial.Length > 100, "A razão social da empresa deve conter no maximo 100 caracteres");

            RazaoSocial = razaoSocial;
        }

        private void ValidateEndereco(string endereco) {
            NFeExceptionValidation.When(string.IsNullOrEmpty(endereco), "O endereco da empresa é obrigatorio");
            NFeExceptionValidation.When(endereco.Length < 5, "O endereco da empresa deve conter no minimo 5 caracteres");
            NFeExceptionValidation.When(endereco.Length > 200, "O endereco da empresa deve conter no maximo 200 caracteres");

            Endereco = endereco;
        }
    }

 
}
