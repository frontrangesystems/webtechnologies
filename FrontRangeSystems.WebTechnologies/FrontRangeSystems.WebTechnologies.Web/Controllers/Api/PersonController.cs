using System.Threading.Tasks;
using System.Web.Http;
using FrontRangeSystems.WebTechnologies.Web.Models;
using FrontRangeSystems.WebTechnologies.Web.Services.Contracts;

namespace FrontRangeSystems.WebTechnologies.Web.Controllers.Api
{
    public class PersonController : ApiController
    {
        public PersonController(IPersonService personService)
        {
            PersonService = personService;
        }

        private IPersonService PersonService { get; }

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await PersonService.GetAsync());
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var model = PersonService.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> Post(PersonModel model)
        {
            var created = await PersonService.CreateAsync(model);
            return CreatedAtRoute("DefaultApi", new {controller = "Person", id = created.Id}, created);
        }

        public async Task<IHttpActionResult> Put(int id, PersonModel model)
        {
            model.Id = id;
            await PersonService.UpdateAsync(id, model);
            return Ok();
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            await PersonService.DeleteAsync(id);
            return Ok();
        }
    }
}