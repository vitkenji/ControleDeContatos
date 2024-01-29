using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Email obrigatório")]
        [EmailAddress(ErrorMessage ="Inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Celular obrigatório")]
        [Phone(ErrorMessage ="Número Inválido")]
        public string Celular { get; set; }
        
    }
}
