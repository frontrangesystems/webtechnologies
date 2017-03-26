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
    public class OrganizationService : IOrganizationService
    {
        public OrganizationService(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        private IDataContext DataContext { get; }

        /// <inheritdoc />
        public async Task<OrganizationModel> GetAsync(int id)
        {
            var entity = await DataContext.Organizations.SingleOrDefaultAsync(o => o.OrganizationId == id);
            return entity.Copy<Organization, OrganizationModel>();
        }

        /// <inheritdoc />
        public async Task<List<OrganizationModel>> GetAsync()
        {
            var list = await DataContext.Organizations.OrderBy(o => o.Name).ToListAsync();
            return list.Select(o => o.Copy<Organization, OrganizationModel>()).ToList();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(int id, OrganizationModel model)
        {
            var entity = model.Copy<OrganizationModel, Organization>();
            DataContext.Entry(entity).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<OrganizationModel> CreateAsync(OrganizationModel model)
        {
            var entity = model.Copy<OrganizationModel, Organization>();
            DataContext.Organizations.Add(entity);
            await DataContext.SaveChangesAsync();

            return entity.Copy<Organization, OrganizationModel>();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            var entity = await DataContext.Organizations.SingleOrDefaultAsync(o => o.OrganizationId == id);
            if (entity != null)
            {
                DataContext.Organizations.Remove(entity);
                await DataContext.SaveChangesAsync();
            }
        }

        /// <inheritdoc />
        public async Task AddPeopleToOrganizationAsync(int organizationId, List<int> personIds)
        {
            await SetOrganizationId(personIds, organizationId);
        }

        /// <inheritdoc />
        public async Task RemovePeopleFromOrganizationAsync(List<int> personIds)
        {
            await SetOrganizationId(personIds, null);
        }

        private async Task SetOrganizationId(List<int> personIds, int? organizationId)
        {
            var people = DataContext.People.Where(p => personIds.Contains(p.PersonId));
            foreach (var person in people)
            {
                person.OrganizationId = organizationId;
            }
            await DataContext.SaveChangesAsync();
        }
    }
}