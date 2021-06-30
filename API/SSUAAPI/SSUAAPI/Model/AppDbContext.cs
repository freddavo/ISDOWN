using System;
using Microsoft.EntityFrameworkCore;

namespace SSUAAPI.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Time> Times { get; set; }
    }
}
