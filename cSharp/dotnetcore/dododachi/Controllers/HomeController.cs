using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace dododachi.Controllers
{
    public class HomeController : Controller
    {
        public static bool IsEffective(){
            Random rand = new Random();
            int noLike = rand.Next(1,4);
            if (noLike == 1){
                return false;
            }
            return true;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int energy = (int)HttpContext.Session.GetInt32("energy");
            if (energy is Int32 == false)
            {
                HttpContext.Session.SetInt32("energy", 50);
                HttpContext.Session.SetInt32("happiness", 20);
                HttpContext.Session.SetInt32("meals", 3);
                HttpContext.Session.SetInt32("fullness", 20);
                HttpContext.Session.SetString("message", "Welcome to dojodachi!");
            }
            ViewBag.energy = HttpContext.Session.GetInt32("energy");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.meals = HttpContext.Session.GetInt32("meals");
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            return View();
        }

        [HttpPost]
        [RouteAttribute("feed")]
        public IActionResult Feed()
        {
            int meals = (int)HttpContext.Session.GetInt32("meals");
            if (meals < 1){
                HttpContext.Session.SetString("message", $"You are out of meals! Work to earn more meals.");
            }else{
                bool effective = IsEffective();
                if (effective == true){
                    HttpContext.Session.SetInt32("meals", meals-1);
                    Random rand = new Random();
                    int fullness = (int)HttpContext.Session.GetInt32("fullness");
                    int increase = rand.Next(5,10);
                    HttpContext.Session.SetInt32("fullness", fullness + increase);
                    HttpContext.Session.SetString("message", $"You fed your dojodachi! Fullness: +{increase} Meals: -1");
                }else{
                    HttpContext.Session.SetInt32("meals", meals-1);
                    HttpContext.Session.SetString("message", $"Your dojodachi is not pleased by your offerring! Fullness: unchanged Meals: -1");
                }
                
            }
            

            return Json(
                new{
                    energy = HttpContext.Session.GetInt32("energy"),
                    happiness = HttpContext.Session.GetInt32("happiness"),
                    meals = HttpContext.Session.GetInt32("meals"),
                    fullness = HttpContext.Session.GetInt32("fullness"),
                    message = HttpContext.Session.GetString("message")
                }
            );
        }

        [HttpPost]
        [RouteAttribute("play")]
        public IActionResult Play()
        {
            int energy = (int)HttpContext.Session.GetInt32("energy");
            if (energy < 5){
                HttpContext.Session.SetString("message", $"You are out of energy! Sleep to gain more energy.");
            }else{
                bool effective = IsEffective();
                if (effective == true){
                    HttpContext.Session.SetInt32("energy", energy-5);
                    Random rand = new Random();
                    int happiness = (int)HttpContext.Session.GetInt32("happiness");
                    int increase = rand.Next(5,10);
                    HttpContext.Session.SetInt32("happiness", happiness + increase);
                    HttpContext.Session.SetString("message", $"You fed your dojodachi! Happiness: +{increase} Energy: -5");
                }else{
                    HttpContext.Session.SetInt32("energy", energy-1);
                    HttpContext.Session.SetString("message", $"Your dojodachi is not pleased by your offerring! Happiness: unchanged Energy: -1");
                }
                
            }
            

            return Json(
                new{
                    energy = HttpContext.Session.GetInt32("energy"),
                    happiness = HttpContext.Session.GetInt32("happiness"),
                    meals = HttpContext.Session.GetInt32("meals"),
                    fullness = HttpContext.Session.GetInt32("fullness"),
                    message = HttpContext.Session.GetString("message")
                }
            );
        }

        [HttpPost]
        [RouteAttribute("work")]
        public IActionResult Work()
        {
            int energy = (int)HttpContext.Session.GetInt32("energy");
            if (energy < 5){
                HttpContext.Session.SetString("message", $"You are out of energy! Sleep to gain more energy.");
            }else{
                HttpContext.Session.SetInt32("energy", energy-5);
                Random rand = new Random();
                int addMeals = rand.Next(1,3);
                int meals = (int)HttpContext.Session.GetInt32("meals");
                HttpContext.Session.SetInt32("meals", meals + addMeals);
                HttpContext.Session.SetString("message", $"You worked! Meals: +{addMeals} Energy: -5");
            }
            

            return Json(
                new{
                    energy = HttpContext.Session.GetInt32("energy"),
                    happiness = HttpContext.Session.GetInt32("happiness"),
                    meals = HttpContext.Session.GetInt32("meals"),
                    fullness = HttpContext.Session.GetInt32("fullness"),
                    message = HttpContext.Session.GetString("message")
                }
            );
        }

        [HttpPost]
        [RouteAttribute("sleep")]
        public IActionResult Sleep()
        {
            int energy = (int)HttpContext.Session.GetInt32("energy");
            int fullness = (int)HttpContext.Session.GetInt32("fullness");
            int happiness = (int)HttpContext.Session.GetInt32("happiness");

            HttpContext.Session.SetInt32("energy", energy+15);
            HttpContext.Session.SetInt32("fullness", fullness-5);
            HttpContext.Session.SetInt32("happiness", happiness-5);
            HttpContext.Session.SetString("message", $"You slept! Energy: +15 Happiness: -5 Fullness: -5");
            

            return Json(
                new{
                    energy = HttpContext.Session.GetInt32("energy"),
                    happiness = HttpContext.Session.GetInt32("happiness"),
                    meals = HttpContext.Session.GetInt32("meals"),
                    fullness = HttpContext.Session.GetInt32("fullness"),
                    message = HttpContext.Session.GetString("message")
                }
            );
        }
    }
}
