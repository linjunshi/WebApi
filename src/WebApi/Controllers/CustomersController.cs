using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

// http://localhost:PORT/swagger/ui/

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {

        private ICustomersRepo cRepo = new CustomersRepo();

        // GET: api/values
        [HttpGet]
        public ICollection<Customer> Get()
        {
            return cRepo.get_all_customers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return cRepo.get_customer(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Customer c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            cRepo.create_customer(c);
            return Ok(c);
        }

        // PUT api/values/5
        [HttpPut]
        public Customer Put([FromBody]Customer c)
        {
            c = cRepo.update_customer(c);
            return c;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            bool b = cRepo.delete_customer(id);
            return b;
        }
    }
}
