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

    //Probably avoid using the method name "Method"
    [HttpPost]
    [Route("method")]
    // public IActionResult Method(string nameField, string locationField, string favLang, string comment)
    public IActionResult SurveyResults(string nameField, string locationField, string favLang, string comment)
    {
        //No need for variables here, you weren't even using two of them (name & userComment)
        // string name = nameField;
        // string loc = locationField;
        // string lang = favLang;
        // string userComment = comment;
        ViewBag.name = nameField;
        ViewBag.location = locationField;
        ViewBag.language = favLang;
        ViewBag.comment = comment;
        return View("Method");
    }
 }
}
