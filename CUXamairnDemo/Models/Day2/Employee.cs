using CUXamairnDemo.Validators;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CUXamairnDemo.Models.Day2
{
    public class Employee
    {
       // [Key]
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(25,ErrorMessage = "name must be less than 25 char")]
        [Unique]//Custom Validation
        public string Name { get; set; }
        [Range(22,40,ErrorMessage ="Age must be in range 22 & 40")]
        public int Age { get; set; }
        [RegularExpression("[a-zA-Z]{5,30}",ErrorMessage ="Address must be char. only")]
        public string  Address { get; set; }
        //SoftDelete
        //public bool isDeleted { get; set; } = false;
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        public virtual Department? Department { get; set; }//null
    }
}
