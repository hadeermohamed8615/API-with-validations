using CUXamairnDemo.Entities;
using System.ComponentModel.DataAnnotations;

namespace CUXamairnDemo.Validators
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = (string)value; //unboxing

            CUXamairnAPI db = new CUXamairnAPI();

            var emp = db.Employees.FirstOrDefault(x => x.Name == name);
            var dept = db.Departments.FirstOrDefault(x => x.Name == name);

            if(emp != null)
            {
                return new ValidationResult("Name Already Exist");
            }
            else if(dept != null) 
            {
                return new ValidationResult("Name Already Exist");
            }
            else
            {
                return ValidationResult.Success;
            }


           // return base.IsValid(value, validationContext);
        }
    }
}
