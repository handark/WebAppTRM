using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAppTRM.Models;

namespace WebAppTRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {

            TasaCambio tasaCambioDolar = null;
            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://trm.joseorozco.co/?fecha=" + fechaActual);
            if (response.IsSuccessStatusCode)
            {
                tasaCambioDolar = await response.Content.ReadAsAsync<TasaCambio>();
            }



            return View(tasaCambioDolar);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
