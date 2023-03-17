using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class IncidentsController : Controller
  {
    private readonly FactoryContext _db;

    public IncidentsController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Incidents.ToList());
    }

    public ActionResult Details(int id)
    {
      Incident thisIncident = _db.Incidents
          .Include(incident => incident.JoinEntities1)
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(incident => incident.IncidentId == id);
      return View(thisIncident);
    }

    public ActionResult Create()
    {
      ViewBag.IncidentId = new SelectList(_db.Incidents, "IncidentId", "Description");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Incident incident)
    {
      if (!ModelState.IsValid)
        {
          return View(incident);
        }
      else
        {
          _db.Incidents.Add(incident);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
    }

    public ActionResult AddMachine(int id)
    {
      Incident thisIncident = _db.Incidents.FirstOrDefault(Incidents => Incidents.IncidentId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Title");
      return View(thisIncident);
    }

    [HttpPost]
    public ActionResult AddMachine(Incident incident, int machineId)
    {
#nullable enable
      IncidentMachine? joinEntity = _db.IncidentMachines.FirstOrDefault(join => (join.MachineId == machineId && join.IncidentId == incident.IncidentId));
#nullable disable
      if (joinEntity == null && machineId != 0)
      {
        _db.IncidentMachines.Add(new IncidentMachine() { MachineId = machineId, IncidentId = incident.IncidentId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = incident.IncidentId });
    }

    public ActionResult Edit(int id)
    {
      Incident thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == id);
      return View(thisIncident);
    }

    [HttpPost]
    public ActionResult Edit(Incident incident)
    {
      _db.Incidents.Update(incident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Incident thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == id);
      return View(thisIncident);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Incident thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == id);
      _db.Incidents.Remove(thisIncident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      IncidentMachine joinEntry = _db.IncidentMachines.FirstOrDefault(entry => entry.IncidentMachineId == joinId);
      _db.IncidentMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}