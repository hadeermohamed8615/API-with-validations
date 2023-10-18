using CUXamairnDemo.Entities;
using CUXamairnDemo.Models.Day2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CUXamairnDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
         CUXamairnAPI Db = new CUXamairnAPI();
      
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { emps = Db.Employees.ToList() });
        }

        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            if(ModelState.IsValid)
         //   if(emp.Name != null & emp.Age > 22)
            {
                Db.Add(emp);
                Db.SaveChanges();
                return RedirectToAction("Get");
            }
            else
            {
                return BadRequest(new { msg = "Not Valid" });  
            }
        }
        [HttpPut]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Db.Update(emp);
                Db.SaveChanges();
                
                return Ok(Db.Employees.ToList());
            }
            else
            {
                return BadRequest(new { msg = "Not Valid" });
            }
        }
    }
}
