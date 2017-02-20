using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using loginReg.Factory;

namespace loginReg.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
 
        //use dependency injection on the HomeController constructor to get a UserFactory object
        public HomeController(UserFactory user) {
            userFactory = user;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
