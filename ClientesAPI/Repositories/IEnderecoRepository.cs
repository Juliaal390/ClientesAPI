using ClientesAPI.Models;

namespace ClientesAPI.Repositories
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<EnderecoModel>> GetAll();
        Task<EnderecoModel> GetById(int id);
        Task<EnderecoModel> Create(EnderecoModel endereco);
        Task<EnderecoModel> Update(EnderecoModel endereco);
        Task<EnderecoModel> Delete(int id);
    }
}
