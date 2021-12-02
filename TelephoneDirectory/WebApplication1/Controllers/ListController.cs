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
            List<Person> person = new List<Person>();
            ViewModel viewmodel = new ViewModel();
            List<Contact> contact = new List<Contact>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Persons");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<List<Person>>(result);
            }

            HttpResponseMessage res2 = await client.GetAsync("api/Contacts");

            if (res2.IsSuccessStatusCode)
            {
                var result = res2.Content.ReadAsStringAsync().Result;
                contact = JsonConvert.DeserializeObject<List<Contact>>(result);
            }

            viewmodel.Tub = new Tuple<List<Person>, List<Contact>>(person, contact);

            return View(viewmodel);

        }
    }
}
