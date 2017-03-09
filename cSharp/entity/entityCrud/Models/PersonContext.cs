using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
namespace entityCrud.Models
{
    public class PersonContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Server = "localhost";
            string Port = "3306";
            string Database = "entityCRUD";
            string UserId = "root";
            string Password = "root";
            string Connection = $"Server={Server};port={Port};database={Database};uid={UserId};pwd={Password};SslMode=None;";
            optionsBuilder.UseMySQL(Connection);
        }

        public DbSet<Person> person { get; set; }
    }
}