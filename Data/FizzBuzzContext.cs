using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Data
{
    public class FizzBuzzContext : DbContext
    {
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
        public FizzBuzzContext(DbContextOptions options) : base(options) { }
    }
}
