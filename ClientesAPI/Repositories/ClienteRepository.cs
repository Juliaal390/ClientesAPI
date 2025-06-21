using ClientesAPI.Data;
using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //Dependências
        private readonly BancoContext _context;
        public ClienteRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<ClienteModel> Create(ClienteModel cliente)
        {
            _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<ClienteModel> Delete(int id)
        {
            var cliente = await GetById(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<ClienteModel>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<ClienteModel> GetById(int id)
        {
            return await _context.Clientes.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ClienteModel> Update(ClienteModel cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
