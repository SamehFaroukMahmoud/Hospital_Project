using Hospital.Models;
using Hospital.services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class BillingController : Controller
    {
        private readonly IBillingService BillingService;

        public BillingController(IBillingService Billing)
        {
            BillingService = Billing;
        }
        public IActionResult Index()
        {
            List<Billing> billing = BillingService.GetBillingsPatients();
            return View(billing);
        }
        [HttpGet]
        public IActionResult CreateBilling()
        {
            ViewBag.selectlistPatient = BillingService.GetlistPatients();
            ViewBag.selectlistPaymentStatus = BillingService.GetListPaymentStatus();
            ViewBag.selectlistAppointment = BillingService.GetlistAppointments();
            return View();
        }
        [HttpPost]
        public IActionResult CreateBilling(Billing Billing)
        {
            ViewBag.selectlistPatient = BillingService.GetlistPatients();
            ViewBag.selectlistPaymentStatus = BillingService.GetListPaymentStatus();
            ViewBag.selectlistAppointment = BillingService.GetlistAppointments();
           
            if (ModelState.IsValid)
            {
                BillingService.InsertBilling(Billing);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditeBilling(int id)
        {
            ViewBag.selectlistPatient = BillingService.GetlistPatients();
            ViewBag.selectlistPaymentStatus = BillingService.GetListPaymentStatus();
            ViewBag.selectlistAppointment = BillingService.GetlistAppointments();


            var Billing = BillingService.GetBillingById(id);
            return View(Billing);
        }
        [HttpPost]
        public IActionResult EditeBilling(Billing Billing)
        {
            ViewBag.selectlistPatient = BillingService.GetlistPatients();
            ViewBag.selectlistPaymentStatus = BillingService.GetListPaymentStatus();
            ViewBag.selectlistAppointment = BillingService.GetlistAppointments();

            BillingService.EditeBilling(Billing);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DetailsBilling(int id)
        {

            var Billing = BillingService.GetBillingById(id);
            return View(Billing);

        }
        [HttpGet]
        public IActionResult DeleteBilling(Billing Billing)
        {

          
            BillingService.DeleteBilling(Billing);
            return RedirectToAction("Index");

        }

    }
}
