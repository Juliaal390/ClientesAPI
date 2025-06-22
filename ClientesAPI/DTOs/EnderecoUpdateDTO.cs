using System.ComponentModel.DataAnnotations;

namespace ClientesAPI.DTOs
{
    public class EnderecoUpdateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Cep é obrigatório")]
        [CepType]
        public string? Cep { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        public string? Numero { get; set; }
        [MaxLength(100)]
        public string? Complemento { get; set; }
    }
}
