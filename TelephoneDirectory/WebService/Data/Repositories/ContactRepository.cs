using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Data.Interfaces;

namespace WebService.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly TelephoneDbContext _context;

        public ContactRepository(TelephoneDbContext context)
        {
            _context = context;
        }
        public void AddContact(Contact entity)
        {
            _context.Contacts.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteContact(int Id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == Id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }

        public IQueryable<Contact> GetAll()
        {
            return _context.Contacts;
        }

        public Contact GetById(int Id)
        {
            return _context.Contacts.FirstOrDefault(c => c.Id == Id);
        }

        public void SaveContact(Contact entity)
        {
            _context.SaveChanges();
        }

        public void UpdateContact(Contact entity)
        {
            _context.SaveChanges();
        }
    }
}
