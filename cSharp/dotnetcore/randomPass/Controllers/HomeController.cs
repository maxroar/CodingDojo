using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace randomPass.Controllers
{
    public class HomeController : Controller
    {
        private static string RandString()
        {
            Random rand = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%?";
            string randomString = "";
            for (int i = 0; i < 15; i++){
                int charIdx = rand.Next(0,68);
                randomString += chars[charIdx];
            }

        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [RouteAttribute("generate")]
        public IActionResult Generate()
        {

        }
    }
}
