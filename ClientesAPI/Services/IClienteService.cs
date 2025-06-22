using ClientesAPI.DTOs;
using ClientesAPI.Models;

namespace ClientesAPI.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAll();
        Task<ClienteDTO> GetById(int id);
        Task<ClienteDTO> GetWithNoTracking(int id);
        Task Add(ClienteDTO cliente);
        Task Update(ClienteDTO cliente);
        Task Remove(int id);
    }
}
