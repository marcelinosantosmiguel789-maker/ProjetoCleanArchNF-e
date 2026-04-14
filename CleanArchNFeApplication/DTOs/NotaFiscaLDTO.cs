using CleanArchNF_eDomain.Enums;
using CleanArchNFeDomain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class NotaFiscalDTO
{
    public int Id { get; set; }

    public int Numero { get; set; }

    public int Serie { get; set; }

    [Required]
    public decimal Total { get; set; }

    public decimal Impostos { get; set; }

    public StatusNotaFiscal Status { get; set; }

    public DateTime DataEmissao { get; set; }

    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }

    public Cliente Cliente { get; set; }

    [ForeignKey("Empresa")]
    public int EmpresaId { get; set; }

    public Empresa Empresa { get; set; }

    public List<ItemNotaFiscal> Itens { get; set; }
}