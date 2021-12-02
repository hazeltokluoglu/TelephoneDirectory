using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Data.Interfaces;

namespace WebService.Data.Repositories
{
    public class AllRepository : IAllRepository
    {
        private readonly TelephoneDbContext _context;

        public AllRepository(TelephoneDbContext context)
        {
            _context = context;
        }

        public List<AllList> GetAll()
        {
            List<AllList> allList = new List<AllList>();

            var query = _context.Persons.Join(_context.Contacts,
        person => person.Id,
        contact => contact.PersonId,
        (person, contact) => new
        {
            Id = person.Id,
            Name = person.Name,
            Surname = person.Surname,
            Company = person.Company,
            TelNumber = contact.TelNumber,
            Email = contact.Email,
            Location = contact.Location
        }).ToList();

            for(int i = 0; i < query.Count; i++)
            {
                allList.Add(
                    new AllList
                    {
                        Id = query[i].Id,
                        Name = query[i].Name,
                        Surname = query[i].Surname,
                        Company = query[i].Company,
                        TelNumber = query[i].TelNumber,
                        Email=query[i].Email,
                        Location=query[i].Location
                    });
            }

            return allList;
        }
    }
}
