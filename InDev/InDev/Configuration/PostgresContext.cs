using Microsoft.EntityFrameworkCore;
using InDev.DbModels;

namespace InDev.Configuration
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }

        public DbSet<DalToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureDalToDo(builder);
        }

        private void ConfigureDalToDo(ModelBuilder builder)
        {
            builder.Entity<DalToDo>().HasKey(m => m.Id);
        }
    }
}
