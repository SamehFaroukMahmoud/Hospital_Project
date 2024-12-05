using Hospital.Models;
using Hospital.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hospital.Controllers
{

    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;
        public DoctorController(IDoctorService doctor)
        {
            doctorService = doctor;
        }
        public IActionResult Index(string? search)
        {
            List<Doctor> doctors = doctorService.GetDoctors(search);
            return View(doctors);
        }
        [HttpGet]
        public IActionResult CreateDoctor()
        {
            ViewBag.listofSpecialization=doctorService.GetListSpecialization();
            return View();
        }
        [HttpPost]


        public IActionResult CreateDoctor(Doctor doctor)
        {
            ViewBag.listofSpecialization = doctorService.GetListSpecialization();
          
            if (ModelState.IsValid)
            {

                doctorService.InsertDoctor(doctor);
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult EditeDoctor(int id)
        {
            ViewBag.listofSpecialization = doctorService.GetListSpecialization();

            var Doctor =doctorService.GetDoctorById(id);
            return View(Doctor);
        }
        [HttpPost]
        public IActionResult EditeDoctor(Doctor doctor)
        {
            ViewBag.listofSpecialization = doctorService.GetListSpecialization();
           

            if (ModelState.IsValid) {
               
                doctorService.EditeDoctor(doctor);
                return RedirectToAction("Index");
            }
            return View();
           
        }
        [HttpGet]
        public IActionResult DetailsDoctor(int id)
        {
                var Doctor = doctorService.GetDoctorById(id);
                return View(Doctor);
        }
        [HttpGet]
        public IActionResult DeleteDoctor(Doctor doctor)
        {
                doctorService.DeleteDoctor(doctor);
              
           
            return RedirectToAction("Index");

        }

    }
}
