using System.Collections.Generic;
using System.Threading.Tasks;
using FrontRangeSystems.WebTechnologies.Web.Models;

namespace FrontRangeSystems.WebTechnologies.Web.Services.Contracts
{
    public interface IPersonService
    {
        Task<PersonModel> GetAsync(int id);
        Task<List<PersonModel>> GetAsync();
        Task UpdateAsync(int id, PersonModel model);
        Task<PersonModel> CreateAsync(PersonModel model);
        Task DeleteAsync(int id);
    }
}