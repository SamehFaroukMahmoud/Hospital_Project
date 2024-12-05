using Hospital.Models;
using Hospital.services;
using Microsoft.EntityFrameworkCore;

namespace Hospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplictionContext>(options =>
              options.UseSqlServer("Data Source=DESKTOP-QIGEBVN;Initial Catalog=Hospital_DB;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True"));
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<INurseService, NurseService>();
            builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            builder.Services.AddScoped<IBillingService,BillingService>();
            builder.Services.AddScoped<IScheduleService, ScheduleService>();
            builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
