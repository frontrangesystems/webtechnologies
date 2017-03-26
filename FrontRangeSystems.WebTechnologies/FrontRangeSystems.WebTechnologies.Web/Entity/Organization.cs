using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrontRangeSystems.WebTechnologies.Web.Entity
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }

        public string Name { get; set; }
        public List<Person> Members { get; set; }
    }
}