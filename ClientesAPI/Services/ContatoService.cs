using AutoMapper;
using ClientesAPI.DTOs;
using ClientesAPI.Models;
using ClientesAPI.Repositories;

namespace ClientesAPI.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _repository;
        private readonly IMapper _mapper;
        public ContatoService(IContatoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(ContatoDTO contato)
        {
            var contatoEntity = _mapper.Map<ContatoModel>(contato);
            await _repository.Create(contatoEntity);
            contato.Id = contatoEntity.Id;
        }

        public async Task<IEnumerable<ContatoDTO>> GetAll()
        {
            var contatoList = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ContatoDTO>>(contatoList);
        }

        public async Task<ContatoDTO> GetById(int id)
        {
            var contato = await _repository.GetById(id);
            return _mapper.Map<ContatoDTO>(contato);
        }

        public async Task Remove(int id)
        {
            var contato = _repository.GetById(id).Result;
            await _repository.Delete(contato.Id);
        }

        public async Task Update(ContatoDTO contato)
        {
            var contatoEntity = _mapper.Map<ContatoModel>(contato);
            await _repository.Update(contatoEntity);
        }
    }
}
