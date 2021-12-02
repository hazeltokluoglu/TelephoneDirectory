using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Data.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        // GET: api/Contacts
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactRepository.GetAll();
        }

        // GET api/Contacts/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _contactRepository.GetById(id);
        }

        // POST api/Contacts
        [HttpPost]
        public void Post([FromBody] Contact value)
        {
            _contactRepository.AddContact(value);
        }

        // PUT api/Contacts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact value)
        {
            _contactRepository.UpdateContact(value);
        }

        // DELETE api/Contacts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _contactRepository.DeleteContact(id);
        }
    }
}
