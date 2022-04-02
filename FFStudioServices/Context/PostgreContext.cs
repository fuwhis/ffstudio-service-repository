using Microsoft.EntityFrameworkCore;
using FFStudioServices.Models;

namespace FFStudioServices.Context
{
    public class PostgreContext: DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {
        }


        public virtual DbSet<Account> Accounts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
