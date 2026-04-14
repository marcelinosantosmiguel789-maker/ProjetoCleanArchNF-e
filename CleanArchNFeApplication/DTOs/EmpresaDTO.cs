using System.ComponentModel.DataAnnotations;

namespace CleanArchNFeApplication.DTOs
{
    public class EmpresaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CNPJ is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ must have 14 digits")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Razão Social is required")]
        [MaxLength(100, ErrorMessage = "Razão Social can have up to 100 characters")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Endereço is required")]
        [MaxLength(200, ErrorMessage = "Endereço can have up to 200 characters")]
        public string Endereco { get; set; }
    }
}