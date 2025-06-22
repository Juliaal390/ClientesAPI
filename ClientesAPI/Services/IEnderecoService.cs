using ClientesAPI.DTOs;
using ClientesAPI.Models;

namespace ClientesAPI.Services
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecoDTO>> GetAll();
        Task<EnderecoDTO> GetById(int id);
        Task<EnderecoDTO> GetWithNoTracking(int id);
        Task Add(EnderecoDTO endereco);
        Task Update(EnderecoDTO endereco);
        Task Remove(int id);
    }
}
