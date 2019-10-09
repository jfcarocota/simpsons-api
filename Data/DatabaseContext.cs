using Microsoft.EntityFrameworkCore;
using todoapi.Models;

namespace todoapi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}

        public DbSet<Character> characters {get; set;}
    }
}