using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string local = @"Data Source=(localdb)\mssqllocaldb;initial catalog=CoreBlogProjectDb;integrated Security=true";
            //string home = @"Data Source=DESKTOP-4VDC1TQ;initial catalog=CoreBlogProjectDb;integrated Security=true";
            optionsBuilder.UseSqlServer(local);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }

    }
}
