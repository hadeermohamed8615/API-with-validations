using CUXamairnDemo.Models.Day2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CUXamairnDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {
        // [HttpGet("{id}")]
        //RouteData --api/Binding/1
        //[HttpGet]
        //QueryString -- api/Binding?id=1
        //RequestBody
        //[HttpPost]
        //Default Value --int = 0; string = null
        //primitive DT=> By Default (RouteData)
        //Complix DT => By Default (Req Body)
        //api/binding/1?Id=7&Name=UI&Loc=Ism\
        [HttpPost("{id}")]
        public ActionResult TestBinding([FromRoute]int id,Department d)
        {

            return Content($"{id}");
        }
    }
}
