using ClientesAPI.DTOs;

namespace ClientesAPI.Services
{
    public interface IContatoService
    {
        Task<IEnumerable<ContatoDTO>> GetAll();
        Task<ContatoDTO> GetById(int id);
        Task<ContatoDTO> GetWithNoTracking(int id);
        Task Add(ContatoDTO contato);
        Task Update(ContatoDTO contato);
        Task Remove(int id);
    }
}
