using Hospital.Models;
using Hospital.services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService  AppointmentService;
        private readonly IMedicalRecordService MedicalRecordService;
        private readonly IBillingService BillingService;

        public AppointmentController(IAppointmentService Appointment, IMedicalRecordService medicalRecordService, IBillingService billingService)
        {
             AppointmentService =  Appointment;
            MedicalRecordService=medicalRecordService;
            BillingService = billingService;
        }

        public IActionResult Index()
        {
            List< Appointment>Appointment =  AppointmentService.GetAppointmentsWithDetails();

            return View(Appointment);
        }
        [HttpGet]
        public IActionResult CreatAppointment()
        {
            ViewBag.GetListStatus =  AppointmentService.GetListStatus();
            ViewBag.GetListDoctor = MedicalRecordService.GetListDoctor();
            ViewBag.GetListPatients = BillingService.GetlistPatients();
            return View();
        }

        [HttpPost]
        public IActionResult CreatAppointment(Appointment Appointment)
        {
            ViewBag.GetListStatus = AppointmentService.GetListStatus();
            ViewBag.GetListDoctor = MedicalRecordService.GetListDoctor();
            ViewBag.GetListPatients = BillingService.GetlistPatients();
           
            if (ModelState.IsValid)
            {
                AppointmentService.InsertAppointment(Appointment);

                return RedirectToAction("Index");
            }
            return View();

        }


        [HttpGet]
        public IActionResult EditeAppointment(int id)
        {
            ViewBag.GetListStatus = AppointmentService.GetListStatus();
            ViewBag.GetListDoctor = MedicalRecordService.GetListDoctor();
            ViewBag.GetListPatients = BillingService.GetlistPatients();

            if (ModelState.IsValid)
            {
                var  Appointment =  AppointmentService.GitById(id);
                return View( Appointment);
            }

            return View();
        }

        [HttpPost]
        public IActionResult EditeAppointment( Appointment  Appointment)
        {
            ViewBag.GetListStatus = AppointmentService.GetListStatus();
            ViewBag.GetListDoctor = MedicalRecordService.GetListDoctor();
            ViewBag.GetListPatients = BillingService.GetlistPatients();

            if (ModelState.IsValid)
            {
                AppointmentService.UpdateAppointment(Appointment);

                return RedirectToAction("Index");

            }
            return View();
           


        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            
                var  Appointment =  AppointmentService.GitById(id);
            return View(Appointment);
            

           

        }
        [HttpGet]
        public IActionResult DeleteAppointment( Appointment  Appointment)
        {

             AppointmentService.DeleteAppointment( Appointment);
            return RedirectToAction("Index");



        }

    }
}
