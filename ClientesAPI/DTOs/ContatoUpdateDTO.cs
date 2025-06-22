using System.ComponentModel.DataAnnotations;

namespace ClientesAPI.DTOs
{
    public class ContatoUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório")]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "O contato é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Texto { get; set; }
    }
}
