using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Patient
  {
    public int PatientID { get; set; }
    public string PatientName { get; set; }
    public int DoctorId { get; set; }
    public List<Doctor> Doctors{ get; set; }
  }
}