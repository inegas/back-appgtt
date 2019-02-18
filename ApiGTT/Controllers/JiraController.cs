using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiGTT.Models;

namespace ApiGTT.Controllers

{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JiraController : ControllerBase
    {
        private readonly AppDBContext _context;
        public JiraController(AppDBContext context)
        {

            this._context = context;
            if (this._context.Jira.Count() == 0)
            {
                Jira jira = new Jira();
                jira.username = "admin";
                jira.username_id = 10;
                this._context.Jira.Add(jira);
                this._context.SaveChanges();
            }
        }


        // GET api/Jira
        [HttpGet]
        public ActionResult<List<Jira>> Get()
        {

            return this._context.Jira.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Jira> Get (long id)
        {
            try
            {
                Jira JiraResult = this._context.Jira.Where(
               jira => jira.username_id.Equals(id)).FirstOrDefault();
                return JiraResult;
            }
            catch(Exception)
            {
                return NotFound();
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult<Jira> Post([FromBody] Jira value)
        {
            try
            {
                Jira JiraResult = this._context.Jira.Where(
                jira => jira.username_id.Equals(value.username_id)).FirstOrDefault();
                this._context.Jira.Add(value);
                this._context.SaveChanges();
                return Ok(value);
            }
            catch
            {
                return NotFound();
           }

            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Jira value)
        {


            Jira JiraResult = this._context.Jira.Where(
            jira => jira.username_id == id).First();
            JiraResult.username = value.username;
            JiraResult.password = value.password;
            JiraResult.url = value.url;
            JiraResult.proyecto = value.proyecto;
            JiraResult.componente = value.componente;
            this._context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}