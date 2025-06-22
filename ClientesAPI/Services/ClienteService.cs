using AutoMapper;
using ClientesAPI.DTOs;
using ClientesAPI.Models;
using ClientesAPI.Repositories;

namespace ClientesAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(ClienteDTO cliente)
        {
            var clienteEntity = _mapper.Map<ClienteModel>(cliente);
            await _repository.Create(clienteEntity);
            cliente.Id = clienteEntity.Id;
        }

        public async Task Remove(int id)
        {
            var cliente = _repository.GetById(id).Result;
            await _repository.Delete(cliente.Id);
        }

        public async Task<IEnumerable<ClienteDTO>> GetAll()
        {
            var clienteList = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clienteList);
        }

        public async Task<ClienteDTO> GetById(int id)
        {
            var cliente = await _repository.GetById(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<ClienteDTO> GetWithNoTracking(int id)
        {
            var cliente = await _repository.GetWithNoTracking(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task Update(ClienteDTO cliente)
        {
            var clienteEntity = _mapper.Map<ClienteModel>(cliente);
            await _repository.Update(clienteEntity);
        }
    }
}
