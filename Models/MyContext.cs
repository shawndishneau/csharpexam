using Microsoft.EntityFrameworkCore;

namespace Exam2.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Association> Associations { get; set; }
    }
}