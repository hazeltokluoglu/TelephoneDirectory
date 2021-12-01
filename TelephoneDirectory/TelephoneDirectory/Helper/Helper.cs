using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelephoneDirectory.Helper
{
    public class Api
    {
        public HttpClient Initial()
        {
            var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
            var uri = "https://localhost:5001/";
            return new HttpClient { BaseAddress = new Uri(uri) };
        }
    }
}
