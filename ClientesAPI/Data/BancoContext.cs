using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ContatoModel> Contatos { get; set; }

        // Fluent API
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Cliente
            mb.Entity<ClienteModel>().HasKey(c => c.Id);

            mb.Entity<ClienteModel>().Property(c => c.Nome)
               .IsRequired()
               .HasMaxLength(100);

            mb.Entity<ClienteModel>().HasOne(c => c.Endereco)
               .WithOne(e => e.Cliente)
               .HasForeignKey<EnderecoModel>(e => e.ClienteId)
               .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<ClienteModel>().HasMany(cl => cl.Contatos)
               .WithOne(co => co.Cliente)
               .HasForeignKey(co => co.ClienteId);

            //Endereco
            mb.Entity<EnderecoModel>().HasKey(e => e.Id);

            mb.Entity<EnderecoModel>().Property(e => e.Cep)
                   .IsRequired()
                   .HasMaxLength(9);

            mb.Entity<EnderecoModel>().HasOne(e => e.Cliente)
                   .WithOne(c => c.Endereco)
                   .HasForeignKey<EnderecoModel>(e => e.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);

            //Contato
            mb.Entity<ContatoModel>().HasKey(c => c.Id);

            mb.Entity<ContatoModel>().Property(c => c.Tipo)
                   .IsRequired();

            mb.Entity<ContatoModel>().Property(c => c.Texto)
                   .IsRequired()
                   .HasMaxLength(100);

            mb.Entity<ContatoModel>().HasOne(co => co.Cliente)
                   .WithMany(cl => cl.Contatos)
                   .HasForeignKey(co => co.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
