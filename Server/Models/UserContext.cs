using Microsoft.EntityFrameworkCore;
using J2S.Shared;


namespace J2S.Server.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) {}

        public DbSet<User>?  Users { get; set; }


    }
}

