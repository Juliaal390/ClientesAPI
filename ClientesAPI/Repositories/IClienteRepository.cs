using ClientesAPI.Models;

namespace ClientesAPI.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteModel>> GetAll();
        Task<ClienteModel> GetById(int id);
        Task<ClienteModel> GetWithNoTracking(int id);
        Task<ClienteModel> Create(ClienteModel cliente);
        Task<ClienteModel> Update(ClienteModel cliente);
        Task<ClienteModel> Delete(int id);

    }
}
