using Dworki.Blog.Web.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dworki.Blog.Web.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}