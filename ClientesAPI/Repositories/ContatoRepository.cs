using ClientesAPI.Data;
using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        //Dependências
        private readonly BancoContext _context;
        public ContatoRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<ContatoModel> Create(ContatoModel contato)
        {
            _context.Contatos.AddAsync(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task<ContatoModel> Delete(int id)
        {
            var contato = await GetById(id);
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task<IEnumerable<ContatoModel>> GetAll()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<ContatoModel> GetById(int id)
        {
            return await _context.Contatos.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public Task<ContatoModel> Update(ContatoModel contato)
        {
            throw new NotImplementedException();
        }
    }
}
