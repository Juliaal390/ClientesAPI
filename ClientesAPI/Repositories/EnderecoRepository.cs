using ClientesAPI.Data;
using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        //Dependências
        private readonly BancoContext _context;
        public EnderecoRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<EnderecoModel> Create(EnderecoModel endereco)
        {
            _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<EnderecoModel> Delete(int id)
        {
            var endereco = await GetById(id);
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<IEnumerable<EnderecoModel>> GetAll()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<EnderecoModel> GetById(int id)
        {
            return await _context.Enderecos.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<EnderecoModel> GetWithNoTracking(int id)
        {
            return await _context.Enderecos.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<EnderecoModel> Update(EnderecoModel endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return endereco;
        }
    }
}
