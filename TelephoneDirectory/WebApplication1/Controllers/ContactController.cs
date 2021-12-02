using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task<ActionResult> Details(int id)
        {
            Contact contact = new Contact();

            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Contacts/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<Contact>(result);
            }
            return View(contact);

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
            person.Insert(0, new Person { Id = 0 , Surname="Select"});
            ViewBag.ListOfPerson = person;

            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection,Contact contacts)
        {
            Contact contact = new Contact();

            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                StringContent content = new StringContent(JsonConvert.SerializeObject(contacts), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("api/Contacts", content);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    contact = JsonConvert.DeserializeObject<Contact>(result);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(contact);

        }

        // GET: ContactController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Contact contact = new Contact();
            List<Person> personlist = new List<Person>();

            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Persons");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                personlist = JsonConvert.DeserializeObject<List<Person>>(result);
            }

            HttpResponseMessage res2 = await client.GetAsync($"api/Contacts/{id}");

            if (res2.IsSuccessStatusCode)
            {
                var result = res2.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<Contact>(result);
            }

            ViewBag.personId = contact.PersonId;
            ViewBag.ListOfPerson = personlist;

            return View(contact);

        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection,Contact contact)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                StringContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync($"api/Contacts/{id}", content);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    contact = JsonConvert.DeserializeObject<Contact>(result);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);

        }

        // GET: ContactController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Contact contact = new Contact();

            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Contacts/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<Contact>(result);
            }

            return View(contact);

        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection,Contact contact)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                HttpResponseMessage res = await client.DeleteAsync($"api/Contacts/{id}");

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    contact = JsonConvert.DeserializeObject<Contact>(result);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);

        }
    }
}
