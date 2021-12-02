using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TelephoneDirectory.Helper;

namespace TelephoneDirectory.Controllers
{
    public class ContactController : Controller
    {
        private readonly Api _api = new Api();

        // GET: ContactController
        public async Task<ActionResult> Index()
        {
            List<Contact> contact = new List<Contact>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Contacts");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<List<Contact>>(result);
            }

            return View(contact);
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactController/Create
        public async Task<ActionResult> Create()
        {
            List<Person> person = new List<Person>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Persons");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<List<Person>>(result);
            }

            person.Insert(0, new Person { Id = 0 });
            ViewBag.ListOfPerson = person;

            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
