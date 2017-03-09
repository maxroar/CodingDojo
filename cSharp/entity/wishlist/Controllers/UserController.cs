using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wishlist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using wishlist.ViewModels;
using System.Linq;

namespace wishlist.Controllers
{
    public class UserController : Controller
    {

        private UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
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
                    password = Hasher.HashPassword(regModel, regModel.password),
                    createdAt = DateTime.Now,
                    updatedAt = DateTime.Now
                };

                User isInDB = _context.Users.Where(u => u.email == user.email).SingleOrDefault();

                if(isInDB != null){
                    ViewBag.error = "This email is already registered. Please log in.";
                    return View("Login");
                }
                else{
                    // userFactory.AddUser(user);
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    User newUser = _context.Users.Last();
                
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
                User isInDB = _context.Users.Where(u => u.email == loginModel.email).SingleOrDefault();

                if(isInDB == null){
                    ViewBag.error = "This email isn't registered. Please register.";
                    return View("Register");
                }
                
                HttpContext.Session.SetInt32("user", isInDB.id);
                return RedirectToAction("Success");
            }
            return View("Login", loginModel);
        }

        [HttpGetAttribute]
        [RouteAttribute("success")]
        public IActionResult Success(){

            return RedirectToAction("Wishlist", "Item");
        }

        [HttpGetAttribute]
        [RouteAttribute("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
