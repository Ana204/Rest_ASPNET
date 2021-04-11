using IMPLEMENTAÇÃO_VERBOS.Model;
using Microsoft.EntityFrameworkCore;

namespace implementação_Verbos.model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){}

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}

        public DbSet<Person> Persons {get; set;}
    }
}