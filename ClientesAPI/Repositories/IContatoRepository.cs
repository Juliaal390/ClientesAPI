using ClientesAPI.Models;

namespace ClientesAPI.Repositories
{
    public interface IContatoRepository
    {
        Task<IEnumerable<ContatoModel>> GetAll();
        Task<ContatoModel> GetById(int id);
        Task<ContatoModel> Create(ContatoModel contato);
        Task<ContatoModel> Update(ContatoModel contato);
        Task<ContatoModel> Delete(int id);
    }
}
