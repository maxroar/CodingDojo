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
            return randomString;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string sessionString = HttpContext.Session.GetString("randomString");
            if (sessionString is String == false)
            {
                HttpContext.Session.SetString("randomString", RandString());
                HttpContext.Session.SetInt32("totalNum", 1);
            }
            ViewBag.randomString = HttpContext.Session.GetString("randomString");
            ViewBag.totalNum = HttpContext.Session.GetInt32("totalNum");
            return View();
        }

        [HttpPost]
        [RouteAttribute("generate")]
        public IActionResult Generate()
        {
            int totalAttempts = (int)HttpContext.Session.GetInt32("totalNum");
            HttpContext.Session.SetString("randomString", RandString());
            HttpContext.Session.SetInt32("totalNum", totalAttempts+1);

            return Json(
                new{
                    randomString = HttpContext.Session.GetString("randomString"),
                    totalNum = HttpContext.Session.GetInt32("totalNum")
                }
            );
        }
    }
}
