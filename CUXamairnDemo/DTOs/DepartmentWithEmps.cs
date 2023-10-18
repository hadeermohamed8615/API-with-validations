using CUXamairnDemo.Models.Day2;
using CUXamairnDemo.Validators;

namespace CUXamairnDemo.DTOs
{
    public class DepartmentWithEmps
    {
        public int DepartmentId { get; set; }
        [Unique]
        public string DepartmentName { get; set; }

        public List<string> EmpsName { get; set; }// =new List<string>();
    }
}
