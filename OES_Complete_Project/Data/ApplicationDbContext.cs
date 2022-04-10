using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OES_Complete_Project.Models;

namespace OES_Complete_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Technology> Technology { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Reports> Reports { get; set; }
    }
}