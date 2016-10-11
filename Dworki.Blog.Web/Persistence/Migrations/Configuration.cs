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

        protected override void Seed(Persistence.ApplicationDbContext context)
        {
        }
    }
}
