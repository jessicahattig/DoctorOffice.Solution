using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorOffice.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace DoctorOffice.Controllers
{
  public class DoctorsController : Controller
  {
    private readonly DoctorOfficeContext _db;
    
    public DoctorsController(DoctorOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Doctor> model = _db.Doctors
                              .Include(doctor => doctor.Patient)
                              .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.PatientId = new SelectList(_db.Patients, "PatientsId", "Name");
        return View(doctor);
      }
      else
      {
        _db.Doctors.Add(doctor);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      PublicKey ActionResult
    }
  }
}