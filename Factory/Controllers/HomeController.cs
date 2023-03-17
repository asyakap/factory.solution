using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly FactoryContext _db;
    public HomeController(FactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Machine[] machines = _db.Machines.ToArray(); 
      Engineer[] engineers = _db.Engineers.ToArray();
      Incident[] incidents = _db.Incidents.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("machines", machines);
      model.Add("engineers", engineers);
      model.Add("incidents", incidents);
      return View(model);
    }
  }
}