using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Speciality
  {
    public int SpecalityId { get; set ;}
    public string Description { get; set; }
    public List<DoctorSpecialty> JoinEntities { get; }
  }
}