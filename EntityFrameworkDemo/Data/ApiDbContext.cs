using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

       public DbSet<Usuario> Usuarios { get; set; }
    }
}
