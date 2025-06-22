using ClientesAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientesAPI.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Nome { get; set; }
        [DateType("dd/MM/yyyy")]
        public string? DataCadastro { get; set; }

        [JsonIgnore]
        public EnderecoModel? Endereco { get; set; }
        [JsonIgnore]
        public ICollection<ContatoModel>? Contatos { get; set; }
    }
}
