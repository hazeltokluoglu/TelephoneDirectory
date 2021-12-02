using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebService.Data.Interfaces;

namespace WebService.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TelephoneDbContext _context;
        public PersonRepository(TelephoneDbContext context)
        {
            _context = context;
        }
        public void AddPerson(Person entity)
        {
            _context.Persons.Add(entity);
            _context.SaveChanges();
        }

        public void DeletePerson(int Id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id == Id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }
        }

        public IQueryable<Person> GetAll()
        {
            return _context.Persons;
        }

        public Person GetById(int Id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == Id);
        }

        public void SavePerson(Person entity)
        {
            _context.SaveChanges();
        }

        public void UpdatePerson(Person entity)
        {
            _context.SaveChanges();
        }
    }
}
