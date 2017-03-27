using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using FrontRangeSystems.WebTechnologies.Web.Models;
using FrontRangeSystems.WebTechnologies.Web.Services.Contracts;

namespace FrontRangeSystems.WebTechnologies.Web.Controllers.Api
{
    public class OrganizationController : ApiController
    {
        public OrganizationController(IOrganizationService organizationService)
        {
            OrganizationService = organizationService;
        }

        private IOrganizationService OrganizationService { get; }


        public async Task<IHttpActionResult> Get()
        {
            return Ok(await OrganizationService.GetAsync());
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var model = await OrganizationService.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> Post(OrganizationModel model)
        {
            var created = await OrganizationService.CreateAsync(model);
            return CreatedAtRoute("DefaultApi", new {controller = "Person", id = created.OrganizationId}, created);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(OrganizationModel model)
        {
            await OrganizationService.UpdateAsync(model);
            return Ok();
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            await OrganizationService.DeleteAsync(id);
            return Ok();
        }

        [Route("{organizationId}/addmembers")]
        public async Task<IHttpActionResult> PostAddPeopleToOrganization(int organizationId, List<int> personIds)
        {
            await OrganizationService.AddPeopleToOrganizationAsync(organizationId, personIds);
            return Ok();
        }

        [Route("{organizationId}/removemembers")]
        public async Task<IHttpActionResult> PostRemovePeopleFromOrganization(List<int> personIds)
        {
            await OrganizationService.RemovePeopleFromOrganizationAsync(personIds);
            return Ok();
        }
    }
}