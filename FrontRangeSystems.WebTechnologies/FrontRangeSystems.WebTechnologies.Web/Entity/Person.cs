using System.ComponentModel.DataAnnotations.Schema;

namespace FrontRangeSystems.WebTechnologies.Web.Entity
{
    [Table("Person")]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}