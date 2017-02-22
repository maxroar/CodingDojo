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
    public class WallController : Controller
    {
        private readonly UserFactory userFactory;
        private readonly WallFactory wallFactory;
 
        //use dependency injection on the HomeController constructor to get a UserFactory object
        public WallController(WallFactory wall, UserFactory user) {
            wallFactory = wall;
            userFactory = user;
        }
       
        // GET: /Home/
        [HttpGet]
        [Route("DisplayWall")]
        public IActionResult DisplayWall()
        {
            User user = userFactory.GetUserByID((int)HttpContext.Session.GetInt32("user"));

            ViewBag.user = user;

            ViewBag.posts = wallFactory.GetAllPosts();
            return View("Wall");
        }

        [HttpPostAttribute]
        [Route("AddPost")]
        public IActionResult AddPost(Post post)
        {
            

            wallFactory.AddPost(post.content, (int)HttpContext.Session.GetInt32("user"));

            return RedirectToAction("DisplayWall");
        }
        
    }
}
