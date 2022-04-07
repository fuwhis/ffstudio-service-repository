using Microsoft.EntityFrameworkCore;
using FFStudioServices.Models;

namespace FFStudioServices.Context
{
    public partial class PostgreContext: DbContext
    {
        public PostgreContext() { }
        
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
