using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wishlist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using wishlist.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace wishlist.Controllers
{
    public class ItemController : Controller
    {

        private UserContext _context;
        public ItemController(UserContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("Wishlist")]
        public IActionResult Wishlist()
        {
            List<Item> itemList = _context.Items.Include(item => item.Wishes).ThenInclude(wish => wish.user).ToList();
            ViewBag.current = _context.Users.Where(u => u.id == HttpContext.Session.GetInt32("user")).Include(usey => usey.Wishes).ThenInclude(wishy => wishy.item).ToList();
            
            return View("Wishlist", _context.Items.ToList());
        }

        
    }
}
