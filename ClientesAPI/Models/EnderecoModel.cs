namespace ClientesAPI.Models;

public class EnderecoModel
{
    public int Id { get; set; }
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Cidade { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }

    //relação 1:1
    public int ClienteId { get; set; } 
    public ClienteModel? Cliente { get; set; }
}
