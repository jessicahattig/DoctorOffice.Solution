using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;

namespace DoctorOffice.Controllers
{
  public class HomeController : Controller
  {
    private readonly DoctorOfficeContext _db;
    public HomeController(DoctorOfficeContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Doctor[] doctors = _db.Doctors.ToArray();
      Specialty[] specialties = _db.Specialties.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("doctors", doctors);
      model.Add("specialties", specialties);
      return View(model);

    }
  }
}