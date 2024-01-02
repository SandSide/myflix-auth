using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Myflix.AuthService.Models;

namespace Myflix.AuthService.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
