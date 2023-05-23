using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FizzBuzzWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
