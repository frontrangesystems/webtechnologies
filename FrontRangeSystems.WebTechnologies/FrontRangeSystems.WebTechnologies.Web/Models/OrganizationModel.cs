using System.Collections.Generic;

namespace FrontRangeSystems.WebTechnologies.Web.Models
{
    public class OrganizationModel
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public List<PersonModel> Members { get; set; }
    }
}