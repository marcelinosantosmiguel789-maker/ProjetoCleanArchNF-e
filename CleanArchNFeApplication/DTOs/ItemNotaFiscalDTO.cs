using System.ComponentModel.DataAnnotations;
using CleanArchNFeApplication;
using CleanArchNFeDomain.Entities;



namespace CleanArchNFeApplication.DTOs
{
    public class ItemNotaFiscalDTO
    {
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public int Serie { get; set; }

        [Required(ErrorMessage = "ClienteId is required")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "EmpresaId is required")]
        public int EmpresaId { get; set; }

        [Required]
        public List<ItemNotaFiscal> Itens { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Total { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Impostos { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }
    }
}