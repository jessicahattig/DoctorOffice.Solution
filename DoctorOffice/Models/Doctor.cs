using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Doctor
  {
    public string DoctorName { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public List<DoctorSpecialty> JoinEntities { get; set; }
  }
}

//DoctorID
//SpecalityID
//PatientID
//Doctor Name

