using ClientesAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientesAPI.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Cidade { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }

        //relação 1:1
        [JsonIgnore]
        public ClienteModel? Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}
