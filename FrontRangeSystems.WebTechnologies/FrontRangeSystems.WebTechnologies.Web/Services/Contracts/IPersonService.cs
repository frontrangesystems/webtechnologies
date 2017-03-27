using System.Collections.Generic;
using System.Threading.Tasks;
using FrontRangeSystems.WebTechnologies.Web.Models;

namespace FrontRangeSystems.WebTechnologies.Web.Services.Contracts
{
    public interface IPersonService
    {
        /// <summary>
        ///     Gets the person with the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<PersonModel> GetAsync(int id);

        /// <summary>
        ///     Gets all people.
        /// </summary>
        /// <returns></returns>
        Task<List<PersonModel>> GetAsync();

        /// <summary>
        ///     Updates the person.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task UpdateAsync(PersonModel model);

        /// <summary>
        ///     Creates a person.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<PersonModel> CreateAsync(PersonModel model);

        /// <summary>
        ///     Deletes the person.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}