using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FrontRangeSystems.WebTechnologies.Web.Data;
using FrontRangeSystems.WebTechnologies.Web.Entity;
using FrontRangeSystems.WebTechnologies.Web.Helpers;
using FrontRangeSystems.WebTechnologies.Web.Models;
using FrontRangeSystems.WebTechnologies.Web.Services.Contracts;

namespace FrontRangeSystems.WebTechnologies.Web.Services
{
    public class PersonService : IPersonService
    {
        public PersonService(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        private IDataContext DataContext { get; }

        /// <inheritdoc />
        public async Task<PersonModel> GetAsync(int id)
        {
            var entity = await DataContext.People.FirstOrDefaultAsync(p => p.PersonId == id);
            return entity.Copy<Person, PersonModel>();
        }

        /// <inheritdoc />
        public async Task<List<PersonModel>> GetAsync()
        {
            var entities = await DataContext.People.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToListAsync();
            return entities.Select(e => e.Copy<Person, PersonModel>()).ToList();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(int id, PersonModel model)
        {
            var entity = model.Copy<PersonModel, Person>();
            DataContext.Entry(entity).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<PersonModel> CreateAsync(PersonModel model)
        {
            var entity = model.Copy<PersonModel, Person>();

            DataContext.People.Add(entity);
            await DataContext.SaveChangesAsync();

            return entity.Copy<Person, PersonModel>();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            var entity = await DataContext.People.FirstOrDefaultAsync(p => p.PersonId == id);

            if (entity != null)
            {
                DataContext.People.Remove(entity);
                await DataContext.SaveChangesAsync();
            }
        }
    }
}