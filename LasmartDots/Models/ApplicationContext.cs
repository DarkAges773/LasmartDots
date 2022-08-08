using Microsoft.EntityFrameworkCore;

namespace LasmartDots.Models
{
	public class ApplicationContext : DbContext
	{
        public DbSet<Dot> Dots { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { 
            Database.EnsureCreated();
        }
    }
}
