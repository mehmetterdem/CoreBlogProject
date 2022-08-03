using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4VDC1TQ;initial catalog=CoreBlogApiDb;integrated Security=true");
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
