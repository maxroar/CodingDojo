using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
 public class HelloController : Controller
 {
  [HttpGet]
  [Route("")]
  public IActionResult Index()
  {
   return View("Index");
  }
  [HttpPost]
    [Route("method")]
    public IActionResult Method(string TextField, int NumberField)
    {
        int numinput = NumberField;
        System.Console.WriteLine(numinput);
        string textinput = TextField;
        System.Console.WriteLine(textinput);
        Dictionary<string, object> viewData = new Dictionary<string, object>();
        ViewData["texty"] = textinput;
        ViewData["numby"] = numinput;
        return View("Method");
    }
 }
}
