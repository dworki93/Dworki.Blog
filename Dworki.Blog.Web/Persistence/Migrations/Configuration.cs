using Dworki.Blog.Web.Core.Models;
using Dworki.Blog.Web.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;

namespace Dworki.Blog.Web.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Persistence\Migrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Uncomment for seed debuging
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            SeedRoles(context);
            SeedUsers(context);
            SeedPages(context, 3);
            SeedPosts(context, 20);
            SeedTags(context, 50);
            SeedPostTags(context, 50);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Administrator"))
            {
                var role = new IdentityRole { Name = "Administrator" };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Moderator"))
            {
                var role = new IdentityRole { Name = "Moderator" };
                roleManager.Create(role);
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new ApplicationUser() { UserName = "Admin", Email = "admin@domain.org" };
                var result = userManager.Create(user, "12345678");
                if (result.Succeeded)
                    userManager.AddToRole(user.Id, "Administrator");
            }
            if (!context.Users.Any(u => u.UserName == "Mod"))
            {
                var user = new ApplicationUser() { UserName = "Mod", Email = "mod@domain.org" };
                var result = userManager.Create(user, "12345678");
                if (result.Succeeded)
                    userManager.AddToRole(user.Id, "Moderator");
            }
        }

        private void SeedPages(ApplicationDbContext context, int numberOfPages)
        {
            var adminId = context.Set<ApplicationUser>()
                .FirstOrDefault(u => u.UserName == "Admin")?.Id;
            if (adminId == null)
                throw new ArgumentNullException(nameof(adminId));

            for (var i = 0; i < numberOfPages; i++)
            {
                var page = new Page()
                {
                    Id = i + 1,
                    ApplicationUserId = adminId,
                    Contents = $"Content of Page {i + 1}",
                    Title = $"Title of Page {i + 1}",
                    DateTime = RandomDataTime(),
                    Visibility = Visibility.Visible
                };
                context.Set<Page>().AddOrUpdate(page);
            }
            context.SaveChanges();
        }

        private void SeedPosts(ApplicationDbContext context, int numberOfPosts)
        {
            var adminId = context.Set<ApplicationUser>()
                .FirstOrDefault(u => u.UserName == "Admin")?.Id;
            if (adminId == null)
                throw new ArgumentNullException(nameof(adminId));

            var modId = context.Set<ApplicationUser>()
                .FirstOrDefault(u => u.UserName == "Mod")?.Id;
            if (modId == null)
                throw new ArgumentNullException(nameof(modId));

            for (var i = 1; i <= numberOfPosts; i++)
            {
                var post = new Post()
                {
                    Id = i,
                    ApplicationUserId = i >= numberOfPosts / 2 ? adminId : modId,
                    Contents = $"Contents of post {i}",
                    Title = $"Title of post {i}",
                    Visibility = Visibility.Visible,
                    DateTime = RandomDataTime()
                };
                context.Set<Post>().AddOrUpdate(post);
            }
            context.SaveChanges();
        }

        private void SeedTags(ApplicationDbContext context, int numberOfTags)
        {
            for (var i = 1; i <= numberOfTags; i++)
            {
                var tag = new Tag()
                {
                    Id = i,
                    Name = $"Name of tag {i}"
                };
                context.Set<Tag>().AddOrUpdate(tag);
            }
            context.SaveChanges();
        }

        private void SeedPostTags(ApplicationDbContext context, int numberOfPostTags)
        {
            for (var i = 0; i < numberOfPostTags; i++)
            {
                var postTag = new PostTag()
                {
                    Id = i + 1,
                    PostId = i % 20 + 1,
                    TagId = i + 1
                };
                context.Set<PostTag>().AddOrUpdate(postTag);
            }
            context.SaveChanges();
        }

        private DateTime RandomDataTime()
        {
            var random = new Random();
            return new DateTime(random.Next(2014, 2017), random.Next(1, 12), random.Next(1, 28));
        }
    }
}