using APICatalogo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {}

        public DbSet<Student>? Students { get; set; }
        public DbSet<Post>? Posts { get; set; }

    }
}
