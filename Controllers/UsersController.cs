using log4net;
using Microsoft.AspNetCore.Mvc;
using quick_asp_api_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quick_asp_api_sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ApplicationContext _db;

        public UsersController(ApplicationContext db)
        {
            log.Debug("ctor");
            _db = db;
            if (!_db.Users.Any())
            {
                _db.Users.Add(new User { Name = "Alex", Age = 40 });
                _db.Users.Add(new User { Name = "Misha", Age = 10 });
                _db.SaveChanges();
            }
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            log.Debug("Get");
            return _db.Users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
