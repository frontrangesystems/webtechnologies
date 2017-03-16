using System.Data.Entity;
using FrontRangeSystems.WebTechnologies.Web.Entity;

namespace FrontRangeSystems.WebTechnologies.Web.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("FrsConnection")
        {
        }

        public IDbSet<Person> People { get; set; }
    }
}