using Microsoft.EntityFrameworkCore;

namespace ExamApp.Models
{
    public class myDbContext : DbContext
    {
        public myDbContext(DbContextOptions<myDbContext> options):base(options)
        {

        }
        public DbSet<Department> department { get; set; }
        public DbSet<Trackers> trackers { get; set; }   
        public DbSet<AtachFile> atachFiles { get; set; }
    }
}
