using Hospital.Models;
using Hospital.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;
        public PatientController(IPatientService patient)
        {
            patientService= patient;
        }
        
        public IActionResult Index(string?search)
        {

            List<Patient> patient = patientService.GetPatients(search);

                return View("Index", patient);

            
           
        }
        [HttpGet]
        public IActionResult CreatPatient()
        {
            
            ViewBag.Gander =patientService.GetListGender();
            return View();
        }

        [HttpPost]
        public IActionResult CreatPatient(Patient patient)
        {
            ViewBag.Gander = patientService.GetListGender();
        
            if (ModelState.IsValid)
            {
              
                patientService.InsertPatient(patient);

                return RedirectToAction("Index");

            }
            ViewBag.Gander = patientService.GetListGender();

            return View();
           
        }
        [HttpGet]
        public IActionResult EditePatient(int id)
        {

            if (ModelState.IsValid)
            {
                ViewBag.Gander = patientService.GetListGender();

                var patient = patientService.GitById(id);
                return View(patient);
            }

            return View();
        }

        [HttpPost]
        public IActionResult EditePatient(Patient Newpatient)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Gander = patientService.GetListGender();
                patientService.UpdatePatient(Newpatient);
                return RedirectToAction("Index");
            }
            return View();

            
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var patient = patientService.GitById(id);
                return View(patient);
            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult DeletePatient(Patient patient)
        {
            
            patientService.DeletePatient(patient);
                return RedirectToAction("Index");

            
            
        }
    }
 }
