namespace ClientesAPI.Models;

public class ContatoModel
{
    public int Id { get; set; }
    public string? Tipo { get; set; } 
    public string? Texto { get; set; }

    // relação 1:N
    public int ClienteId { get; set; }
    public ClienteModel? Cliente { get; set; }
}
