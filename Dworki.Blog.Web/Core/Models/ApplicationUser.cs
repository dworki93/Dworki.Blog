using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dworki.Blog.Web.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public virtual ICollection<Post> Posts { get; private set; }

        public virtual ICollection<Page> Pages { get; private set; }

        public ApplicationUser()
        {
            Posts = new HashSet<Post>();
            Pages = new HashSet<Page>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}