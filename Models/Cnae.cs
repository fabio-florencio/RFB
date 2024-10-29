using System.ComponentModel.DataAnnotations;

namespace RFB.Models
{
    public class Cnae
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "Código")]
        public string Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Esse campo é obrigatório!!")]
        [StringLength(1000)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;
    }
}
