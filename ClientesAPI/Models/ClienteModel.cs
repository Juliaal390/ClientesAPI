namespace ClientesAPI.Models;

public class ClienteModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? DataCadastro { get; set; }
    public EnderecoModel? Endereco { get; set; } //relação 1:1
    public ICollection<ContatoModel>? Contatos { get; set; } //relação 1:N
}
