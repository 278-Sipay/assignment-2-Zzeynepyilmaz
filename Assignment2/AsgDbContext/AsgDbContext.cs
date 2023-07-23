using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.AsgDbContext
{
    public class AsgDbContext
    {
        public AsgDbContext(DbContextOptions<AsgDbContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transaction { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //There are some errors on database are gonna fix
    }
}
