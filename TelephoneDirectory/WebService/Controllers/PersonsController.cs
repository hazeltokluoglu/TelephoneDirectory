using DataAccess;
using DataAccess.Abstract;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET: api/Persons
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personRepository.GetAll();
        }
        // GET api/Persons/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _personRepository.GetById(id);
        }
        // POST api/Persons
        [HttpPost]
        public void Post([FromBody] Person value)
        {
            _personRepository.AddPerson(value);
        }

        // PUT api/Persons/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Person value)
        {
            _personRepository.UpdatePerson(value);
        }

        // DELETE api/Persons/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _personRepository.DeletePerson(id);
        }
    }
}
