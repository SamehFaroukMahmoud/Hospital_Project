using Hospital.Models;
using Hospital.services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordService MedicalRecordService; IBillingService BillingService ;
        public MedicalRecordController( IMedicalRecordService medicalRecordService, IBillingService billingService)
        {
            
            MedicalRecordService = medicalRecordService;
            BillingService = billingService;
        }
        public IActionResult Index()
        {
            var medicalRecords = MedicalRecordService.GetMedicalRecords();
            return View(medicalRecords);
        }
        [HttpGet]
        public IActionResult CreateMedicalRecord()
        {
            ViewBag.listOfPatient= BillingService.GetlistPatients();
            ViewBag.listOfDoctor = MedicalRecordService.GetListDoctor();
            ViewBag.listOfPrescription = MedicalRecordService.GetListPrescription();

            return View();
        }
        [HttpPost]
        public IActionResult CreateMedicalRecord(MedicalRecord MedicalRecord)
        {
            ViewBag.listOfPatient = BillingService.GetlistPatients();
            ViewBag.listOfDoctor = MedicalRecordService.GetListDoctor();
            ViewBag.listOfPrescription = MedicalRecordService.GetListPrescription();
            

            if (ModelState.IsValid)
            {
                MedicalRecordService.InsertMedicalRecord(MedicalRecord);
                return RedirectToAction("Index");

            }
            return View();
          
        }
        [HttpGet]
        public IActionResult EditeMedicalRecord(int id)
        {
            ViewBag.listOfPatient = BillingService.GetlistPatients();
            ViewBag.listOfDoctor = MedicalRecordService.GetListDoctor();
            ViewBag.listOfPrescription = MedicalRecordService.GetListPrescription();
           
                var MedicalRecord = MedicalRecordService.GetMedicalRecordById(id);
                return View(MedicalRecord);
         
           
        }
        [HttpPost]
        public IActionResult EditeMedicalRecord(MedicalRecord MedicalRecord)
        {
            ViewBag.listOfPatient = BillingService.GetlistPatients();
            ViewBag.listOfDoctor = MedicalRecordService.GetListDoctor();
            ViewBag.listOfPrescription = MedicalRecordService.GetListPrescription();
            if (ModelState.IsValid)
            {
                MedicalRecordService.EditeMedicalRecord(MedicalRecord);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult DetailsMedicalRecord(int id)
        {

            var MedicalRecord = MedicalRecordService.GetMedicalRecordById(id);
            return View(MedicalRecord);

        }
        [HttpGet]
        public IActionResult DeleteMedicalRecord(MedicalRecord MedicalRecord)
        {
            MedicalRecordService.DeleteMedicalRecord(MedicalRecord);
            return RedirectToAction("Index");

        }

    }
}
