using BookifyV5.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookifyV5.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Category>().Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(builder);
        }
    }
}
