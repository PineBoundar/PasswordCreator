using System.Data.Entity;

namespace PasswordCreator.Models
{
    class DatabaseContext : DbContext
    {
        public DbSet<PasswordItem> Passwords { get; set; }
    }
}
