using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testApp.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Group> Groups { get; set; }
        public List<Organization> Organizations { get; set; }
    }
}
