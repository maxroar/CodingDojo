using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers
{
 public class DojoSurveyController : Controller
 {
  [HttpGet]
  [Route("")]
  public IActionResult Index()
  {
   return View("Index");
  }
  [HttpPost]
    [Route("method")]
    public IActionResult Method(string nameField, string locationField, string favLang, string comment)
    {
        string name = nameField;
        string loc = locationField;
        string lang = favLang;
        string userComment = comment;
        ViewBag.name = nameField;
        ViewBag.location = loc;
        ViewBag.language = lang;
        ViewBag.comment = comment;
        return View("Method");
    }
 }
}
