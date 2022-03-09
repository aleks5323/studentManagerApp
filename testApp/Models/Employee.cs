using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Organization Org { get; set; }
        public virtual List<Group> Groups { get; set; }
    }
}
