using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Entities
{
    public class LibraryContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Post> Post { get; set; }
    }
}