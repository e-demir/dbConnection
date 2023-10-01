using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace consoledeneme.DataAccess
{
    public class SchoolContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server = localhost,57000; Database = dev_testdb1; User Id = sa; Password = Str#ng_Passw#rd;TrustServerCertificate=True;");
    }    
}

