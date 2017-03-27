using System.Data.Entity.Migrations;
using FrontRangeSystems.WebTechnologies.Web.Data;
using FrontRangeSystems.WebTechnologies.Web.Entity;

namespace FrontRangeSystems.WebTechnologies.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "FrontRangeSystems.WebTechnologies.Web.Data.DataContext";
        }

        protected override void Seed(DataContext context)
        {
            SeedOrganizations(context);
            SeedPeople(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void SeedPeople(DataContext context)
        {
            var id = 1;
            var poet = 1;
            var author = 2;
            var playwright = 3;
            context.People.AddOrUpdate(
                p=>p.PersonId,
                new Person
                {
                    PersonId = id++,
                    OrganizationId = poet,
                    FirstName = "Walt",
                    LastName = "Whitman"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = poet,
                    FirstName = "Emily",
                    LastName = "Dickinson"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = poet,
                    FirstName = "Robert",
                    LastName = "Frost"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = poet,
                    FirstName = "Edgar Allan",
                    LastName = "Poe"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = poet,
                    FirstName = "Maya",
                    LastName = "Angelou"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = poet,
                    FirstName = "Oscar",
                    LastName = "Wilde"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = author,
                    FirstName = "Stephen",
                    LastName = "King"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = author,
                    FirstName = "J. K.",
                    LastName = "Rowling"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = author,
                    FirstName = "C. S.",
                    LastName = "Lewis"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = author,
                    FirstName = "Mark",
                    LastName = "Twain"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = author,
                    FirstName = "J. R. R.",
                    LastName = "Tolkien"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = playwright,
                    FirstName = "William",
                    LastName = "Shakespeare"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = playwright,
                    FirstName = "Arthur",
                    LastName = "Miller"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = playwright,
                    FirstName = "Tennesee",
                    LastName = "Williams"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = playwright,
                    FirstName = "Neil",
                    LastName = "Simon"
                },
                new Person
                {
                    PersonId = id++,
                    OrganizationId = playwright,
                    FirstName = "August",
                    LastName = "Wilson"
                });

            context.SaveChanges();
        }

        private void SeedOrganizations(DataContext context)
        {
            var id = 1;
            context.Organizations.AddOrUpdate(
                new Organization
                {
                    OrganizationId = id++,
                    Name = "Poets"
                },
                new Organization
                {
                    OrganizationId = id++,
                    Name = "Authors"
                },
                new Organization
                {
                    OrganizationId = id++,
                    Name = "Playwrights"
                });

            context.SaveChanges();
        }
    }
}