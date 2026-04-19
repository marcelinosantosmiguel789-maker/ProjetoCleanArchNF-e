using CleanArchNF_eDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNF_eDomain.Enums;
using CleanArchNF_eDomain.Validation;

namespace CleanArchNFeDomain.Entities
{
    public sealed class NotaFiscal : Entity
    {
        public int Numero { get; set; }
        public int Serie { get; set; }
        public Cliente Cliente { get; set; }
        public Empresa Empresa { get; set; }
        public List<ItemNotaFiscal> Itens { get; set; }
        public decimal Total { get; set; }
        public decimal Impostos { get; set; }
        public StatusNotaFiscal Status { get; set; }
        public DateTime DataEmissao { get; set; }
        public int ClienteId { get; set; }
        public int EmpresaId { get; set; }

        public NotaFiscal() { }

        public NotaFiscal(int numero, int serie, Cliente cliente, Empresa empresa, List<ItemNotaFiscal> itens, decimal total, decimal impostos,StatusNotaFiscal status, DateTime dataEmissao)
        {
            ValidateNumero(numero);
            ValidateSerie(serie);
            ValidateCliente(cliente);
            ValidateEmpresa(empresa);
            ValidateItens(itens);
            ValidateTotal(total);
            ValidateImpostos(impostos);
            DateValidate(dataEmissao);
            if (!Enum.IsDefined(typeof(StatusNotaFiscal), status))
            {
                throw new NFeExceptionValidation("Status da nota fiscal é inválido");
            }
                Status = status;
            
            CalcularTotal();
        }
        private void ValidateNumero(int numero)
        {
            NFeExceptionValidation.When(numero <= 0, "O numero da nota fiscal é obrigatorio e deve ser maior que zero");
            Numero = numero;
        }
        private void ValidateSerie(int serie)
        {
            NFeExceptionValidation.When(serie <= 0, "A serie da nota fiscal é obrigatoria e deve ser maior que zero");
            Serie = serie;
        }
        private void ValidateCliente(Cliente cliente)
        {
            NFeExceptionValidation.When(cliente == null, "O cliente da nota fiscal é obrigatorio");
            Cliente = cliente;
        }
        private void ValidateEmpresa(Empresa empresa)
        {
            NFeExceptionValidation.When(empresa == null, "A empresa da nota fiscal é obrigatoria");
            Empresa = empresa;
        }
        private void ValidateItens(List<ItemNotaFiscal> itens)
        {
            NFeExceptionValidation.When(itens == null || itens.Count == 0, "A nota fiscal deve conter pelo menos um item");
            Itens = itens;
        }
        private void ValidateTotal(decimal total)
        {
            NFeExceptionValidation.When(total <= 0, "O total da nota fiscal é obrigatorio e deve ser maior que zero");
            Total = total;
        }
        private void ValidateImpostos(decimal impostos)
        {
            NFeExceptionValidation.When(impostos < 0, "O valor dos impostos da nota fiscal é obrigatorio e deve ser maior ou igual a zero");
            Impostos = impostos;
        }
        public void CalcularTotal()
        {
            Total = Itens.Sum(i => i.ValorUnitario * i.Quantidade);
            Impostos = Total * 0.1m; // Exemplo de cálculo de impostos (10% do total)
        }
        public void DateValidate(DateTime dataEmissao)
        {
            NFeExceptionValidation.When(dataEmissao > DateTime.Now, "A data de emissão da nota fiscal não pode ser futura");
            NFeExceptionValidation.When(dataEmissao ==  DateTime.MinValue , "A data de emissão da nota fiscal é obrigatoria");

           DataEmissao = dataEmissao;
        }

        // Aggregate operations
        public void AdicionarItem(ItemNotaFiscal item)
        {
            NFeExceptionValidation.When(item == null, "Item é obrigatório");
            if (Itens == null) Itens = new List<ItemNotaFiscal>();
            Itens.Add(item);
            CalcularTotal();
        }

        public void RemoverItemPorProduto(int produtoId)
        {
            if (Itens == null || !Itens.Any())
                throw new NFeExceptionValidation("A nota fiscal não possui itens");

            var item = Itens.FirstOrDefault(i => i.ProdutoId == produtoId);
            NFeExceptionValidation.When(item == null, "Item não encontrado na nota fiscal");

            Itens.Remove(item);
            CalcularTotal();
        }
    }
}
