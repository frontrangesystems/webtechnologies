using System.Collections.Generic;
using System.Threading.Tasks;
using FrontRangeSystems.WebTechnologies.Web.Models;

namespace FrontRangeSystems.WebTechnologies.Web.Services.Contracts
{
    public interface IOrganizationService
    {
        /// <summary>
        ///     Gets an organization with the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<OrganizationModel> GetAsync(int id);

        /// <summary>
        ///     Gets all orginzations.
        /// </summary>
        /// <returns></returns>
        Task<List<OrganizationModel>> GetAsync();

        /// <summary>
        ///     Updates the organization.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task UpdateAsync(OrganizationModel model);

        /// <summary>
        ///     Creates an orginzation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<OrganizationModel> CreateAsync(OrganizationModel model);

        /// <summary>
        ///     Deletes the orginzation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        ///     Adds the people to organization.
        /// </summary>
        /// <param name="organizationId">The organization identifier.</param>
        /// <param name="personIds">The person ids.</param>
        /// <returns></returns>
        Task AddPeopleToOrganizationAsync(int organizationId, List<int> personIds);

        /// <summary>
        ///     Removes the people from the specified organization.
        /// </summary>
        /// <param name="personIds">The person ids.</param>
        /// <returns></returns>
        Task RemovePeopleFromOrganizationAsync(List<int> personIds);
    }
}