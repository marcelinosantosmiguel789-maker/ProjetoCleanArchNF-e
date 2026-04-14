using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchNFeApplication.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cliente name is required")]
        [MinLength(3)]
        [MaxLength(50)]
        public string nome { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Pessoa is required")]
        [MinLength(3)]
        [MaxLength(50)]
        public string documento { get; set; }
    }

}
