using AutoMapper;
using ClientesAPI.DTOs;
using ClientesAPI.Models;
using ClientesAPI.Repositories;
using System.Runtime.ConstrainedExecution;

namespace ClientesAPI.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        private readonly IMapper _mapper;
        
        public EnderecoService(IEnderecoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(EnderecoDTO endereco)
        {

            var enderecoEntity = _mapper.Map<EnderecoModel>(endereco);
            await _repository.Create(enderecoEntity);
            endereco.Id = enderecoEntity.Id;
        }

        public async Task<IEnumerable<EnderecoDTO>> GetAll()
        {
            var enderecoList = await _repository.GetAll();
            return _mapper.Map<IEnumerable<EnderecoDTO>>(enderecoList);
        }

        public async Task<EnderecoDTO> GetById(int id)
        {
            var endereco = await _repository.GetById(id);
            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public async Task Remove(int id)
        {
            var endereco = _repository.GetById(id).Result;
            await _repository.Delete(endereco.Id);
        }

        public async Task Update(EnderecoDTO endereco)
        {
            var enderecoEntity = _mapper.Map<EnderecoModel>(endereco);
            await _repository.Update(enderecoEntity);
        }
    }
}
