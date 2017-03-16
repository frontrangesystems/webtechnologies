using System.Data.Entity;
using FrontRangeSystems.WebTechnologies.Web.Data;
using FrontRangeSystems.WebTechnologies.Web.Migrations;

namespace FrontRangeSystems.WebTechnologies.Web
{
    public static class DatabaseHelper
    {
        public static void ApplyMigrations()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
        }
    }
}