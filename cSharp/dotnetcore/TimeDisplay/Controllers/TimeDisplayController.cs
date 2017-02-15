using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers
{
 public class TimeDisplayController : Controller
 {
  [HttpGet]
  [Route("")]
  public IActionResult Index()
  {
      DateTime datetime = DateTime.Now;
      System.Console.WriteLine(datetime);
      ViewData["time"] = datetime.ToString("f");
      return View("Index");
  }
  
 }
}
