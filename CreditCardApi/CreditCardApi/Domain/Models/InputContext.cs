using Microsoft.EntityFrameworkCore;

namespace CreditCardApi.Domain.Models
{
    public class InputContext : DbContext
    {
        public InputContext(DbContextOptions<InputContext> options)
            : base(options)
        {
        }

        public DbSet<Input> InputList { get; set; }

        public DbSet<CreditCard> CardList { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}
