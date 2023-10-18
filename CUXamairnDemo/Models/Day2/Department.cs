using CUXamairnDemo.Validators;
using System.Text.Json.Serialization;

namespace CUXamairnDemo.Models.Day2
{
    public class Department
    {
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
       // [JsonIgnore]
        public string? Location { get; set; }
        //[JsonIgnore] 
        public virtual ICollection<Employee>? Employees { get; set; } 
       // public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
