using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace APITest.Models
{
    public class SuperHeroContext : DbContext
    {
        public SuperHeroContext(DbContextOptions<SuperHeroContext> options) : base(options)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; } = null;
    }
}
