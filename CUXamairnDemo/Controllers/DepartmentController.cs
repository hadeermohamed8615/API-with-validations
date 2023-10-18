using CUXamairnDemo.DTOs;
using CUXamairnDemo.Entities;
using CUXamairnDemo.Models.Day2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CUXamairnDemo.Controllers
{
    [Route("api/[controller]")]//api/Department
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        CUXamairnAPI Db = new CUXamairnAPI();
        [HttpGet]
        public ActionResult Get()
        {
            var depts = Db.Departments.Include(e=>e.Employees).ToList();
            //Declaration DTO Obj
            List<DepartmentWithEmps> DeptEmpDTO = new List<DepartmentWithEmps>();
           
            foreach (var dept in depts)
            {
                List<string> names = new List<string>();
                foreach(var e in dept.Employees) //Search about the soluation
                {
                    if (e.DeptId == dept.Id)
                        names.Add(e.Name);
                    else
                        continue;
                }
                //////////////////
                ///
                DepartmentWithEmps emp = new DepartmentWithEmps() { DepartmentId = dept.Id, DepartmentName = dept.Name, EmpsName = names };
                //emp.DepartmentId= dept.Id;
                //emp.DepartmentName = dept.Name;
                DeptEmpDTO.Add(emp);
             //   names = default;
            }
           
            //depts = default;
            if(depts != null)
            {
                // return Ok(new { Departments = DeptEmpDTO, Message = "Data Exist" });
                return Ok(DeptEmpDTO);
            }
            else
            {
                return NotFound(new { ErrorMessage = "Sorry !!!, No Depts Yet" });
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            var dept = Db.Departments.Include(e=>e.Employees).FirstOrDefault(d=>d.Id==id);
           DepartmentWithEmps deptDto = new DepartmentWithEmps();
            deptDto.DepartmentId = dept.Id;
            deptDto.DepartmentName = dept.Name;
            List<string> names = new List<string>();
            foreach (var e in dept.Employees)
                names.Add(e.Name);
            deptDto.EmpsName = names;
            if (dept != null)
            {
                return Ok(new { deptDto, Message = $"Department with Id = {id} Exist" });
            }
            else
            {
                return NotFound(new { ErrorMessage = $"Sorry !!!, Department with Id = {id} Not Exist" });
            }
        }
        [HttpGet("{name:alpha}")]//api/Department/name
        public ActionResult Get(string name)
        {
            var dept = Db.Departments.FirstOrDefault(d=>d.Name == name);
            if (dept != null)
            {
                return Ok(new { dept, Message = $"Department with Id = {name} Exist" });
            }
            else
            {
                return NotFound(new { ErrorMessage = $"Sorry !!!, Department with Id = {name} Not Exist" });
            }
        }
        [HttpPost]
        public ActionResult Add(Department d)
        {
            if(d != null)
            {
                Db.Departments.Add(d);
                Db.SaveChanges();
                return RedirectToAction("Get");
              //  return Ok(new {depts=Db.Departments.ToList(),Message="Department Added Successfully"});
            }
            else
            {
                return BadRequest(new { ErrorMessage = $"{d} Not Valid" });
            }

        }
        [HttpPut("{id}")]
        public ActionResult Edit(Department NewDept , int id)
        {
            

            if(NewDept.Name != null)
            {
              var OldDept = Db.Departments.FirstOrDefault(d => d.Id == id);
                ///Extra Data 
                ///Send Old Obj to Client
                Department OldV01 = new Department();
                OldV01.Name = OldDept.Name;
                OldV01.Location = OldDept.Location;
                ///Send Obj with update
                OldDept.Name = NewDept.Name;
                OldDept.Location = NewDept.Location;
                ///to update DB
                Db.SaveChanges();
                return Ok(new { Old_Version = OldV01, New_Version = OldDept, Id = id, Message = "Updated" });
            }
            else
            {
                return BadRequest(new {Error_Message="Try Again !!"});
            }
        }
        [HttpPut]
        public ActionResult EditWithUpdateFun(Department d)
        {
            if(d.Name != null)
            {
                //EF 7
                //must send pk of Obj
                //catch the old obj by pk=> if(pk) exist
                //update Obj
                //if PK Not Exist => add Obj 

                Db.Departments.Update(d);
                Db.SaveChanges();
                return Ok(new { message = $"Dept with Id = {d.Id} updated",newObj = d });
            }
            else 
            {
                return BadRequest(new { Error_Message = "Try Again !!" });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dept = Db.Departments.Find(id);
            if(dept != null)
            {
                Db.Remove(dept);
                Db.SaveChanges();
                return Ok(new { DeptDeleted = dept, Message = $"Department wirh Id = {id} is deleted" });
            }
            else
            {
                return NotFound(new { ErrorMessage = $"Department wirh Id = {id} Not Found" });
            }
        }
    }
}
