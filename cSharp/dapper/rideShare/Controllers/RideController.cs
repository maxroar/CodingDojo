using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rideShare.Factory;
using rideShare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using rideShare.ViewModels;

namespace rideShare.Controllers
{
    public class RideController : Controller
    {
        private readonly UserFactory userFactory;
        private readonly RideFactory RideFactory;
 
        //use dependency injection on the HomeController constructor to get a UserFactory object
        public RideController(RideFactory ride, UserFactory user) {
            RideFactory = ride;
            userFactory = user;
        }
       
        // GET: /Home/
        [HttpGet]
        [Route("Dahboard")]
        public IActionResult Dashboard()
        {
            User user = userFactory.GetUserByID((int)HttpContext.Session.GetInt32("user"));

            if(user.isDriver == false){
                return RedirectToAction("CarReg");
            }

            return View("Dashboard");
        }

        // [HttpPostAttribute]
        // [Route("AddPost")]
        // public IActionResult AddPost(Post post)
        // {
            

        //     RideFactory.AddPost(post, (int)HttpContext.Session.GetInt32("user"));

        //     return RedirectToAction("DisplayRide");
        // }

        // [HttpPostAttribute]
        // [Route("AddComment")]
        // public IActionResult AddComment(Comment comment)
        // {
        //     RideFactory.AddComment(comment, (int)HttpContext.Session.GetInt32("user"));

        //     return RedirectToAction("DisplayRide");
        // }
        
        // [HttpPostAttribute]
        // [Route("DeletePost")]
        // public IActionResult DeletePost(Post post)
        // {
        //     RideFactory.DeletePost(post.id);

        //     return RedirectToAction("DisplayRide");
        // }

        // [HttpPostAttribute]
        // [Route("DeleteComment")]
        // public IActionResult DeleteComment(Comment comment)
        // {
        //     RideFactory.DeleteComment(comment.id);

        //     return RedirectToAction("DisplayRide");
        // }
        
    }
}
