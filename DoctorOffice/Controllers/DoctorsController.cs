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
      
      public ActionResult Details(int id)
    {
      Doctor thisDoctor = _db.Doctors
          .Include(doctor => doctor.Patient)
          .Include(doctor => doctor.JoinEntities)
          .ThenInclude(join => join.Specialty)
          .FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }
    
    public ActionResult Edit(int id)
    {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Name");
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult Edit(Doctor doctor)
    {
      _db.Doctors.Update(doctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      _db.Doctors.Remove(thisDoctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddSpecialty(int id)
    {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      ViewBag.TagId = new SelectList(_db.Specialties, "SpecialtyId", "Title");
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult AddSpecialty(Doctor doctor, int specialtyId)
    {
      #nullable enable
      DoctorSpecialty? joinEntity = _db.DoctorSpecialties.FirstOrDefault(join => (join.SpecialtyId == specialtyId && join.DoctorId == doctor.DoctorId));
      #nullable disable
      if (joinEntity == null && specialtyId != 0)
      {
        _db.DoctorSpecialties.Add(new DoctorSpecialty() { SpecialtyIdId = gId, DoctorId = doctor.DoctorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = doctor.DoctorId });
    }   

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      DoctorSpecialty joinEntry = _db.DoctorSpecialties.FirstOrDefault(entry => entry.DoctorSpecialtyId == joinId);
      _db.DoctorSpecialties.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    } 
    }
  }
}