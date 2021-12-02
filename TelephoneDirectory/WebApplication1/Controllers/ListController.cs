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

            return View(list);

        }
        public async Task<IActionResult> Report()
        {

            return View();
        }
    }
}
