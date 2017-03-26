using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using FrontRangeSystems.WebTechnologies.Web.Models;
using FrontRangeSystems.WebTechnologies.Web.Services.Contracts;

namespace FrontRangeSystems.WebTechnologies.Web.Controllers
{
    public class PersonController : Controller
    {
        public PersonController(IPersonService personService)
        {
            PersonService = personService;
        }

        private IPersonService PersonService { get; }

        public async Task<ActionResult> Index()
        {
            return View(await PersonService.GetAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                await PersonService.CreateAsync(personModel);
                return RedirectToAction("Index");
            }

            return View(personModel);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await PersonService.GetAsync(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = await PersonService.GetAsync(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName")] PersonModel model)
        {
            if (ModelState.IsValid)
            {
                await PersonService.UpdateAsync(model.PersonId, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await PersonService.GetAsync(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await PersonService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}