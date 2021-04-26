
using Microsoft.EntityFrameworkCore;

namespace ServiceStatus.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Historic> Historics { get; set; }          //?
        public DbSet<Failure> Failures { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }  //?
        //public DbSet<Admin> Admins { get; set; }              //?
    }
}
