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
                _db.Users.Add(new User { Id = 1, Name = "Alex", Age = 40 });
                _db.Users.Add(new User { Id = 2, Name = "Misha", Age = 10 });
                _db.SaveChanges();
            }
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            log.Debug("Get");
            return _db.Users.ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            log.Debug($"Get: {id}");
            return _db.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User u)
        {
            log.Debug($"Post: {u.Name}, {u.Age}");
            _db.Users.Add(u);
            _db.SaveChanges();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User u)
        {
            log.Debug($"Put: {id}");
            var u1 = _db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (u1 != null)
            {
                u1.Name = u.Name;
                u1.Age = u.Age;
                _db.SaveChanges();
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            log.Debug($"Delete: {id}");
            var u = _db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (u != null)
            {
                _db.Users.Remove(u);
                _db.SaveChanges();
            }
        }
    }
}
