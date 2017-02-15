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
        public bool GameOver(){
            int energy = (int)HttpContext.Session.GetInt32("energy");
            int fullness = (int)HttpContext.Session.GetInt32("fullness");
            int happiness = (int)HttpContext.Session.GetInt32("happiness");

            if (energy > 99 && fullness > 99 && happiness > 99){
                HttpContext.Session.SetString("message", "You win!");
                HttpContext.Session.SetString("image", "win.png");
                return true;
            }else if (fullness < 1 || happiness < 1){
                HttpContext.Session.SetString("message", "You lose!");
                HttpContext.Session.SetString("image", "lose.png");
                return true;
            }else{
                return false;
            }
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            
            if (HttpContext.Session.GetInt32("energy") == null)
            {
                HttpContext.Session.SetInt32("energy", 50);
                HttpContext.Session.SetInt32("happiness", 20);
                HttpContext.Session.SetInt32("meals", 3);
                HttpContext.Session.SetInt32("fullness", 20);
                HttpContext.Session.SetString("message", "Welcome to dojodachi!");
                HttpContext.Session.SetString("image", "welcome.png");
            }

            bool gameOver = GameOver();

            return View();

        }

        [HttpPost]
        [RouteAttribute("reset")]
        public IActionResult Reset()
        {
            System.Console.WriteLine("reset route");
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        [RouteAttribute("getStats")]
        public IActionResult getStats()
        {
            bool gameOver = GameOver();
            System.Console.WriteLine(gameOver);

            return Json(
                new{
                    energy = HttpContext.Session.GetInt32("energy"),
                    happiness = HttpContext.Session.GetInt32("happiness"),
                    meals = HttpContext.Session.GetInt32("meals"),
                    fullness = HttpContext.Session.GetInt32("fullness"),
                    message = HttpContext.Session.GetString("message"),
                    image = HttpContext.Session.GetString("image"),
                    gameOver = gameOver
                }
            );
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
                    HttpContext.Session.SetString("image", "eat.png");
                }else{
                    HttpContext.Session.SetInt32("meals", meals-1);
                    HttpContext.Session.SetString("image", "unpleased.png");
                    HttpContext.Session.SetString("message", $"Your dojodachi is not pleased by your offerring! Fullness: unchanged Meals: -1");
                }
                
            }
            
            bool gameOver = GameOver();

            return Json(
                new{
                    energy = HttpContext.Session.GetInt32("energy"),
                    happiness = HttpContext.Session.GetInt32("happiness"),
                    meals = HttpContext.Session.GetInt32("meals"),
                    fullness = HttpContext.Session.GetInt32("fullness"),
                    message = HttpContext.Session.GetString("message"),
                    image = HttpContext.Session.GetString("image"),
                    gameOver = gameOver
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
                    HttpContext.Session.SetString("message", $"You played with your dojodachi! Happiness: +{increase} Energy: -5");
                    HttpContext.Session.SetString("image", "play.png");
                }else{
                    HttpContext.Session.SetInt32("energy", energy-5);
                    HttpContext.Session.SetString("image", "unpleased.png");
                    HttpContext.Session.SetString("message", $"Your dojodachi is not pleased by your offerring! Happiness: unchanged Energy: -5");
                }
                
            }
            

            bool gameOver = GameOver();

            return Json(
                new{
                    energy = HttpContext.Session.GetInt32("energy"),
                    happiness = HttpContext.Session.GetInt32("happiness"),
                    meals = HttpContext.Session.GetInt32("meals"),
                    fullness = HttpContext.Session.GetInt32("fullness"),
                    message = HttpContext.Session.GetString("message"),
                    image = HttpContext.Session.GetString("image"),
                    gameOver = gameOver
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
                HttpContext.Session.SetString("image", "worked.png");
                HttpContext.Session.SetString("message", $"You worked! Meals: +{addMeals} Energy: -5");
            }
            

            bool gameOver = GameOver();

            return Json(
                new{
                    energy = HttpContext.Session.GetInt32("energy"),
                    happiness = HttpContext.Session.GetInt32("happiness"),
                    meals = HttpContext.Session.GetInt32("meals"),
                    fullness = HttpContext.Session.GetInt32("fullness"),
                    message = HttpContext.Session.GetString("message"),
                    image = HttpContext.Session.GetString("image"),
                    gameOver = gameOver
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
            HttpContext.Session.SetString("image", "sleep.png");
            

            bool gameOver = GameOver();

            return Json(
                new{
                    energy = HttpContext.Session.GetInt32("energy"),
                    happiness = HttpContext.Session.GetInt32("happiness"),
                    meals = HttpContext.Session.GetInt32("meals"),
                    fullness = HttpContext.Session.GetInt32("fullness"),
                    message = HttpContext.Session.GetString("message"),
                    image = HttpContext.Session.GetString("image"),
                    gameOver = gameOver
                }
            );
        }
    }
}
