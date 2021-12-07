using Data;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelephoneDirectory.Controllers
{
    public class ListController : Controller
    {
        private readonly TelephoneDbContext _context;
        public ListController(TelephoneDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
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

            for (int i = 0; i < query.Count; i++)
            {
                allList.Add(
                    new AllList
                    {
                        Id = query[i].Id,
                        Name = query[i].Name,
                        Surname = query[i].Surname,
                        Company = query[i].Company,
                        TelNumber = query[i].TelNumber,
                        Email = query[i].Email,
                        Location = query[i].Location
                    });
            }
            var contact = await _context.Contacts.ToListAsync();
            contact.Insert(0, new Contact { Id = 0, Location = "Select" });
            ViewBag.location = contact;

            return View(allList);
        }
        public async Task<IActionResult> Report(string location)
        {
            var contact = await _context.Contacts.ToListAsync();

            var number = contact.Count(c => c.Location == location);

            var telNum = from n in contact
                         where n.Location == location
                         select n.TelNumber;

            int num = telNum.Count();

            ViewBag.location = location;
            ViewBag.number = number;
            ViewBag.telNumber = num;

            return View();
        }
    }
}
