using ClientesAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientesAPI.DTOs
{
    public class EnderecoCreateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Cep é obrigatório")]
        [CepType]
        public string? Cep { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        public string? Numero { get; set; }
        [MaxLength(100)]
        public string? Complemento { get; set; }
        public int ClienteId { get; set; }
    }
}
