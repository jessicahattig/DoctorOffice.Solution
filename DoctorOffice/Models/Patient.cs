using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public List<Doctor> Doctors{ get; set; }
  }
}