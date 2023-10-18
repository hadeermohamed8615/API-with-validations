using CUXamairnDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CUXamairnDemo.Controllers
{
    [Route("api/[controller]")]//URL=>api/Student
    [ApiController]
    public class StudentController : ControllerBase
    {
       
        //[Route("Hello")] //Relative path
        [Route("/Hello")] //Absolete Path
        [HttpGet]
        //Action Return Types
        //ContentResult => Content (string)
        //JsonResult => Json
        public ContentResult Hello()
        {
            //Declartion Obj
            ContentResult res = new ContentResult();
            //Inilization
            res.Content = "Hello CU";
            //Return 
            return res;
        }
        [HttpGet("Json")]//api/Student/json
        [HttpGet("/Json")]//Domain/json
        public JsonResult HelloJson()
        {
            //Declartion Obj  //Inilization
            JsonResult res = new JsonResult(new { Id = 1, Name = "Mohamed" });
           
            //Return 
            return res;
        }
        // [HttpGet("MixJsonWithContent/{name}")]
        [HttpGet("{name:alpha}")]
        //api/student/aya
        public ActionResult MixJsonWithContent(string name)
        {
            if (name == "Aya")
            { 
                return Content($"Hello{name}");
            }
            else
            {
               
                return new JsonResult(new {id=1,name="Hamada"});
            }

        }
        //api/student/3
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
          
            var std = StudentBL.students.Find(s => s.Id == id);
            if (std != null)
                return Ok(std);
            else
                return NotFound(new { Message = $"Student with Id = {id} Not Found" });
           
           // return StudentBL.students.Find(s => s.Id == id);
        }
        [HttpGet]
        public ActionResult GetAll() //Action
        {
            var stds = StudentBL.students;
           // stds = default;
            if(stds != null)
            {
                return Ok(new { student = stds, Message = "The List Not Empty" });
            }
            else
            {
               return NotFound(new { msg = "Sorry ; No Students Now" });
            }
          
        }
   
        [HttpPost]
        public ActionResult Add(Student student)
        {
            if (student.Address == null)
                return BadRequest(new {Error="Adderess must have avalue"});
            else
            {              
                StudentBL.students.Add(student);   
                return Created("localhost:5268/api/Student", new {students=StudentBL.students ,Message = "Student added Successfuly!!" });
            }
       
         
          //  return StudentBL.students;
        }

        //public List<Student> Update(Student student)
        //{
        //    StudentBL.students.Add(student);
        //    return StudentBL.students;
        //}
        [HttpDelete]
        public List<Student> Delete(int id)
        {
            var std = StudentBL.students.FirstOrDefault(s=>s.Id==id);
            StudentBL.students.Remove(std);
            return StudentBL.students;
        }
    }
}
