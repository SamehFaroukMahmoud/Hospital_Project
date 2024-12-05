using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static Hospital.Models.Enums;

namespace Hospital.Models
{
    public class ApplictionContext:DbContext
    {
        
        public ApplictionContext(DbContextOptions<ApplictionContext>options ):base(options) { }
        
            
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Doctor>()
           // .HasData(new Doctor
           // { Id = 1, Name = "Samy", Email = "samy@gmail.com", ContactNumber = "01144880701", Specialization = Specialization.EyeSurgery, RoomNumber = "102" },
           //new Doctor { Id = 2, Name = "Ahmed", Email = "ahmed@gmail.com", ContactNumber = "01244500701", Specialization = Specialization.Neurology, RoomNumber = "155" });
           // modelBuilder.Entity<Patient>()
           //   .HasData(new Patient { Id = 1, Name = "sameh", ContactNumber = "01119225419", Email = "sameh@gmail.com", Gender = Gender.Male, Address = "zagazig", EmergencyContact = "122" });
           // modelBuilder.Entity<Appointment>()
           // .HasData(new Appointment { Id = 1, Date = DateTime.Now, PatientId =1, DoctorId = 1, Status = Status.Completed ,billingId=null});
        }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
        public DbSet<Doctor> doctors  { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Nurse> nurses { get; set; }
        public DbSet<MedicalRecord> medicalRecords { get; set; }
        public DbSet<Billing> billings { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        



    }
}
