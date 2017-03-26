using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using FrontRangeSystems.WebTechnologies.Web.Entity;

namespace FrontRangeSystems.WebTechnologies.Web.Data
{
    public interface IDataContext
    {
        IDbSet<Person> People { get; }
        IDbSet<Organization> Organizations { get; }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
        Task<int> SaveChangesAsync();
    }
}