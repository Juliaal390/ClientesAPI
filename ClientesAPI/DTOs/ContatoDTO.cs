using ClientesAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientesAPI.DTOs
{
    public class ContatoDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "O tipo é obrigatório")]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "O contato é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Texto { get; set; }

        [JsonIgnore]
        public ClienteModel? Cliente { get; set; }
        public int ClienteId { get; set; }
        
    }
}
