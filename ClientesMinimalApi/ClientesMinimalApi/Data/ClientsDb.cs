using ClientesMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesMinimalApi.Data
{
    public class ClientsDb : DbContext
    {
        public ClientsDb(DbContextOptions<ClientsDb>options) : base(options)  
        {
        
        }


        public DbSet<Clientes> Clientes => Set<Clientes>();
    }
}
