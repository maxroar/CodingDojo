using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using theWall.Factory;
using theWall.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using theWall.ViewModels;

namespace theWall.Controllers
{
    public class UserController : Controller
    {
        private readonly UserFactory userFactory;
 
        //use dependency injection on the HomeController constructor to get a UserFactory object
        public UserController(UserFactory user) {
            userFactory = user;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Register");
        }

        [HttpGet]
        [Route("LoginIndex")]
        public IActionResult LoginIndex()
        {
            return View("Login");
        }

        [HttpPostAttribute]
        [RouteAttribute("register")]
        public IActionResult Register(RegisterViewModel regModel){
            if (ModelState.IsValid)
            {
                PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>();
                User user = new User{
                    fname = regModel.fname,
                    lname = regModel.lname,
                    email = regModel.email,
                    password = Hasher.HashPassword(regModel, regModel.password)
                };
                bool exists = userFactory.CheckUserInDB(user.email);
                if(exists){
                    ViewBag.error = "This email is already registered. Please log in.";
                    return View("Login");
                }
                else{
                    userFactory.AddUser(user);
                    User newUser = userFactory.GetCurrentUser(user.email);
                    // ViewBag.user = newUser;
                
                    HttpContext.Session.SetInt32("user", newUser.id);
                    return RedirectToAction("Success");
                }
            }
            
            return View("Register", regModel);
        }

        [HttpPostAttribute]
        [RouteAttribute("login")]
        public IActionResult Login(LoginViewModel loginModel){
            if (ModelState.IsValid)
            {
                bool exists = userFactory.CheckUserInDB(loginModel.email);
                if(!exists){
                    ViewBag.error = "This email isn't registered. Please register.";
                    return View("Register");
                }
                User user = userFactory.GetCurrentUser(loginModel.email);
                HttpContext.Session.SetInt32("user", user.id);
                return RedirectToAction("Success");
            }
            return View("Login", loginModel);
        }

        [HttpGetAttribute]
        [RouteAttribute("success")]
        public IActionResult Success(){
            
            // ViewBag.user = userFactory.GetCurrentUser(HttpContext.Session.GetString("user"));

            return RedirectToAction("DisplayWall", "Wall");
        }

        [HttpGetAttribute]
        [RouteAttribute("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
