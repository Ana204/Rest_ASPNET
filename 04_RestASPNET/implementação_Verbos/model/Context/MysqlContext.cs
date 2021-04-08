using IMPLEMENTAÇÃO_VERBOS.Model;
using Microsoft.EntityFrameworkCore;

namespace implementação_Verbos.model.Context
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(){}

        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options){}

        public DbSet<Person> Persons {get; set;}
    }
}