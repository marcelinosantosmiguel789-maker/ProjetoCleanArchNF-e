using CleanArchNF_eDomain.Validation;

namespace CleanArchNFeDomain.Entities
{
    public sealed class ItemNotaFiscal : Entity
    {
        public ItemNotaFiscal() { }
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total { get; set; }
        public decimal ValorImpostos { get; set; }
        public ItemNotaFiscal(int produtoId, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Total = quantidade * valorUnitario;
        }

        public ItemNotaFiscal(int produtoId, string descricao, int quantidade, decimal valorUnitario, decimal valorImpostos)
        {
            ValidateProdutoId(produtoId);
            ValidateDescricao(descricao);
            ValidateQuantidade(quantidade);
            ValidateValorUnitario(valorUnitario);
            ValidateValorImpostos(valorImpostos);

            ProdutoId = produtoId;
            Descricao = descricao;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ValorImpostos = valorImpostos;

            CalcularTotal();
        }

        private void ValidateProdutoId(int produtoId)
        {
            NFeExceptionValidation.When(produtoId <= 0,
                "O Id do produto é obrigatorio e deve ser maior que zero");
        }

        private void ValidateDescricao(string descricao)
        {
            NFeExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "A descrição do produto é obrigatoria");

            NFeExceptionValidation.When(descricao.Length < 3,
                "A descrição do produto deve conter no minimo 3 caracteres");

            NFeExceptionValidation.When(descricao.Length > 100,
                "A descrição do produto deve conter no maximo 100 caracteres");
        }

        private void ValidateQuantidade(int quantidade)
        {
            NFeExceptionValidation.When(quantidade <= 0,
                "A quantidade do produto é obrigatoria e deve ser maior que zero");
        }

        private void ValidateValorUnitario(decimal valorUnitario)
        {
            NFeExceptionValidation.When(valorUnitario <= 0,
                "O valor unitário do produto é obrigatorio e deve ser maior que zero");
        }

        private void ValidateValorImpostos(decimal valorImpostos)
        {
            NFeExceptionValidation.When(valorImpostos < 0,
                "O valor dos impostos do produto deve ser maior ou igual a zero");
        }

        private void CalcularTotal()
        {
            Total = Quantidade * ValorUnitario;
        }
    }
}