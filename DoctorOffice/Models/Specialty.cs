using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Specialty
  {
    public int SpecialtyId { get; set ;}
    public string Description { get; set; }
    public List<DoctorSpecialty> JoinEntities { get; }
  }
}