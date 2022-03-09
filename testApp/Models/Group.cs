using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testApp.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
