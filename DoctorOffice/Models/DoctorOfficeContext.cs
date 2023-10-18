using Microsoft.EntityFrameworkCore;

namespace DoctorOffice.Models
{
  public class DoctorOfficeContext : DbContext
  {
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Speciality> Specialties { get; set; }
    public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
    public DoctorOfficeContext(DbContextOptions options) : base(options) { }
    
  }
}