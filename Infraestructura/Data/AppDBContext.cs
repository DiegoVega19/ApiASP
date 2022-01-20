
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <Lugar> Lugar { get; set; }
    }
}
