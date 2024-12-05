using Hospital.Models;
using Hospital.services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IMedicalRecordService MedicalRecordService;
        private readonly IBillingService BillingService;
        private readonly IPrescriptionService prescriptionService;

        public PrescriptionController(IPrescriptionService prescription, IMedicalRecordService medicalRecordService, IBillingService billingService)
        {
            prescriptionService = prescription;
            MedicalRecordService = medicalRecordService;
            BillingService = billingService;
        }
        public IActionResult Index()
        {
            
                var prescrptions = prescriptionService.GetPrescriptions();
                return View("Index", prescrptions);

            
        }
        [HttpGet]
        public IActionResult CreatePrescription()
        {
            ViewBag.listOfPatient =BillingService.GetlistPatients();
            ViewBag.listOfDoctor = MedicalRecordService.GetListDoctor();

            return View();
        }
        [HttpPost]
        public IActionResult CreatePrescription(Prescription prescription)
        {
            ViewBag.listOfPatient = BillingService.GetlistPatients();
            ViewBag.listOfDoctor = MedicalRecordService.GetListDoctor();
          
            if (ModelState.IsValid)
            {
                prescriptionService.InsertPrescription(prescription);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditePrescription(int id)
        {
            ViewBag.listOfPatient = BillingService.GetlistPatients();
            ViewBag.listOfDoctor = MedicalRecordService.GetListDoctor();

            var Prescription =prescriptionService.GetPrescriptionId(id);
            return View(Prescription);
        }
        [HttpPost]
        public IActionResult EditePrescription(Prescription prescription)
        {
            ViewBag.listOfPatient = BillingService.GetlistPatients();
            ViewBag.listOfDoctor = MedicalRecordService.GetListDoctor();
            prescriptionService.UpdatePrescription(prescription);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DetailsPrescription(int id)
        {
            var Prescription = prescriptionService.GetPrescriptionId(id);
            return View(Prescription);
        }
        [HttpGet]
        public IActionResult DeletePrescription(Prescription prescription)
        {
            prescriptionService.DeletePrescription(prescription);

            return RedirectToAction("Index");
        }

    }
}
