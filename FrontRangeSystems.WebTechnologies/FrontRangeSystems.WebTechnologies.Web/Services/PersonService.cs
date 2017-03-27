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
            var entity = await DataContext.People.Include(p=>p.Organization).FirstOrDefaultAsync(p => p.PersonId == id);
            return CreateModel(entity);
        }

        /// <inheritdoc />
        public async Task<List<PersonModel>> GetAsync()
        {
            var entities = await DataContext.People
                .Include(p => p.Organization)
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToListAsync();
            return entities.Select(CreateModel).ToList();
        }

        private PersonModel CreateModel(Person person)
        {
            var model = person.Copy<Person, PersonModel>();
            if (person.Organization != null)
            {
                model.OrganizationName = person.Organization.Name;
            }
            return model;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(PersonModel model)
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