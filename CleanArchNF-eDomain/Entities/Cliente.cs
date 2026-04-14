using CleanArchNF_eDomain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchNFeDomain.Entities
{
    public sealed class Cliente : Entity
    {
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public Cliente(string documento, string nome, string endereco)
        {
     
            ValidateDocumento(documento);
            ValidateNome(nome);
            ValidateEndereco(endereco);
        }
        public Cliente() {}

        // Method used by repository to update entity values
        public void Atualizar(string documento, string nome, string endereco)
        {
            ValidateDocumento(documento);
            ValidateNome(nome);
            ValidateEndereco(endereco);
        }


        private void ValidateNome(string nome)
        {
           NFeExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome do cliente é obrigatorio");

            NFeExceptionValidation.When(nome.Length < 3, "O nome do cliente deve conter no minimo 3 caracteres");

            NFeExceptionValidation.When(nome.Length > 100, "O nome do cliente deve conter no maximo 100 caracteres");

            Nome = nome;
        }

        private void ValidateDocumento(string documento)
        {
            NFeExceptionValidation.When(string.IsNullOrEmpty(documento), "O documento do cliente é obrigatorio");
            NFeExceptionValidation.When(documento.Length < 11, "O documento do cliente deve conter no minimo 11 caracteres");
            NFeExceptionValidation.When(documento.Length > 14, "O documento do cliente deve conter no maximo 14 caracteres");

               Documento = documento;
        }

        private void ValidateEndereco(string endereco)
        {
            NFeExceptionValidation.When(string.IsNullOrEmpty(endereco), "O endereco do cliente é obrigatorio");
            NFeExceptionValidation.When(endereco.Length < 5, "O endereco do cliente deve conter no minimo 5 caracteres");
            NFeExceptionValidation.When(endereco.Length > 200, "O endereco do cliente deve conter no maximo 200 caracteres");

            Endereco = endereco;
        }

    }
}