using Microsoft.EntityFrameworkCore;

namespace ClientDataAPI.Model
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; } = null;
    }
}
