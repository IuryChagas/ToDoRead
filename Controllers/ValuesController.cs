using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ToDoRead.Controllers
{
    [Route("api/[controller]")][ApiController]
    public class ValuesController
    {
        [HttpGet] public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value 1", "value 2" };
        }

        [HttpGet("{id}")] public ActionResult<string>  Get(int id)
        {
            return "value";
        }
        [HttpPut("{id}")] public void Put(int id, [FromBody] string value)
        {
            
        }

        [HttpDelete("{id}")] public void Delete(int id)
        {

        }

    }
}