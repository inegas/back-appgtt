using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiGTT.Models;
using ApiGTT.Helpers;

namespace api_gtt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/values
        private readonly AppDBContext _context;

        public UsersController(AppDBContext context)
        {
            this._context = context;
            if (this._context.Users.Count() == 0)
            {
                Users user = new Users();
                user.username = "admin";
                user.password = Encrypt.Hash("1234");
                this._context.Users.Add(user);
                this._context.SaveChanges();
            }

        }


        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            return this._context.Users.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(long id)
        {
            Users user = this._context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users value)
        {
            
            this._context.Users.Add(value);
            this._context.SaveChanges();
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Users value)
        {
            Users user = this._context.Users.Find(id);
            user.username = value.username;
            user.password = value.password;
            this._context.SaveChanges();
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Users userDelete = this._context.Users.Where((user) => id == id).First();
            this._context.Remove(userDelete);
            this._context.SaveChanges();
        }
    }
}