using System.ComponentModel.DataAnnotations;

namespace testApp.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tin { get; set; }
        public Teacher Teacher { get; set; }
    }
}
