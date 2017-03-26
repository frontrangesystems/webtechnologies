using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontRangeSystems.WebTechnologies.Web.Entity
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [ForeignKey(nameof(Organization))]
        public int? OrganizationId { get; set; }

        public Organization Organization { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}