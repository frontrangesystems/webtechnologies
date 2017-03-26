using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using FrontRangeSystems.WebTechnologies.Web.Models;
using FrontRangeSystems.WebTechnologies.Web.Services.Contracts;

namespace FrontRangeSystems.WebTechnologies.Web.Controllers
{
    public class OrganizationsController : Controller
    {
        public OrganizationsController(IOrganizationService organizationService)
        {
            OrganizationService = organizationService;
        }

        private IOrganizationService OrganizationService { get; }

        public async Task<ActionResult> Index()
        {
            return View(await OrganizationService.GetAsync());
        }

        public async Task<ActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await OrganizationService.GetAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] OrganizationModel organization)
        {
            if (ModelState.IsValid)
            {
                await OrganizationService.CreateAsync(organization);
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var organization = await OrganizationService.GetAsync(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] OrganizationModel organization)
        {
            if (ModelState.IsValid)
            {
                await OrganizationService.UpdateAsync(organization.OrganizationId, organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var organization = await OrganizationService.GetAsync(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await OrganizationService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}