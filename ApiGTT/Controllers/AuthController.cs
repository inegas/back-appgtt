using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ApiGTT.Models;

using ApiGTT.Helpers;

using System.Web.Http;
namespace GttApiWeb.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class AuthController : ControllerBase

    {
        public AuthController(AppDBContext contex)

        {

            this._context = contex;

        }
        private readonly AppDBContext _context;

        // GET api/values

        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()

        {

            return new string[] { "value1", "value2" };

        }        // GET api/values/5

        [HttpGet("{ id}")]

        public ActionResult<string> Get(int id)

        {

            return "value";

        }        // POST api/values

        [HttpPost]

        public ActionResult Post([FromBody] Users value)
        {
            try
            {
                Users UserResult = this._context.Users.Where(
                user => user.username.Equals(value.username)).FirstOrDefault();

                Console.WriteLine(UserResult.username);

                if (UserResult != null)
                {
                    if (UserResult.password == (value.password))
                    {
                        
                       return Ok(value);
                    }
                }
               return Unauthorized();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
         // PUT api/values/5

        [HttpPut("{id}")]
    
        public void Put(int id, [FromBody] string value)

        { }        // DELETE api/values/5

        [HttpDelete("{id}")]

        public void Delete(int id)

        {

        }

    }

}