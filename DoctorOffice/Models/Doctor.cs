using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class DoctorOffice
  {
    public int DoctorID { get; set; }
    public string DoctorName { get; set; }
    public List<DoctorSpecialty> JoinEntities { get; set; }
  }
}

//DoctorID
//SpecalityID
//PatientID
//Doctor Name