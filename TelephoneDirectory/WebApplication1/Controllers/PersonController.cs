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
    public class PersonController : Controller
    {
        private readonly Api _api = new Api();
        // GET: PersonController
        public async Task<ActionResult> Index()
        {
            List<Person> person = new List<Person>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Persons");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<List<Person>>(result);
            }

            return View(person);
        }

        // GET: PersonController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Person person = new Person();

            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Persons/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<Person>(result);
            }
            return View(person);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection,Person persons)
        {
            Person person = new Person();

            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                StringContent content = new StringContent(JsonConvert.SerializeObject(persons), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("api/Persons", content);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    person = JsonConvert.DeserializeObject<Person>(result);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: PersonController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Person person = new Person();

            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Persons/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<Person>(result);
            }
            return View(person);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection,Person person)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync($"api/Persons/{id}", content);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    person = JsonConvert.DeserializeObject<Person>(result);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);

        }

        // GET: PersonController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Person person = new Person();

            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Persons/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<Person>(result);
            }
            return View(person);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection,Person person)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                HttpResponseMessage res = await client.DeleteAsync($"api/Persons/{id}");

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    person = JsonConvert.DeserializeObject<Person>(result);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
    }
}
