using Entity;
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
    public class ListController : Controller
    {
        private readonly Api _api = new Api();

        public async Task<IActionResult> Index()
        {
            List<AllList> list = new List<AllList>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Alls");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<AllList>>(result);
            }

            List<Contact> contact = new List<Contact>();

            HttpResponseMessage res2 = await client.GetAsync("api/Contacts");

            if (res2.IsSuccessStatusCode)
            {
                var result = res2.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<List<Contact>>(result);
            }
            contact.Insert(0, new Contact { Id = 0, Location = "Select" });
            ViewBag.location = contact;

            return View(list);

        }
        public async Task<IActionResult> Report(string location)
        {
            List<Contact> contact = new List<Contact>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res2 = await client.GetAsync("api/Contacts");

            if (res2.IsSuccessStatusCode)
            {
                var result = res2.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<List<Contact>>(result);
            }

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
