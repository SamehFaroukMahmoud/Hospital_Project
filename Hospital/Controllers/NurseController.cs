using Hospital.Models;
using Hospital.services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class NurseController : Controller
    {

        private readonly INurseService nurseService;
        public NurseController(INurseService nurse)
        {
            nurseService = nurse;
        }
        public IActionResult Index(string?search)
        {
            List<Nurse> nurses = nurseService.GetNurse(search);
            return View(nurses);
        }
        [HttpGet]
        public IActionResult CreateNurse()
        {
            ViewBag.listShift=nurseService.GetListShift();
            return View();
        }
        [HttpPost]
        public IActionResult CreateNurse(Nurse nurse)
        {
            if (ModelState.IsValid)
            {

                nurseService.InsertNurse(nurse);
                return RedirectToAction("Index");

            }
            ViewBag.listShift = nurseService.GetListShift();

            return View();
            
        }
        [HttpGet]
        public IActionResult EditeNurse(int id)
        {
            ViewBag.listShift = nurseService.GetListShift();

            var nurse = nurseService.GetNurseById(id);
            return View(nurse);
        }
        [HttpPost]
        public IActionResult EditeNurse(Nurse nurse)
        { if (ModelState.IsValid)
            {

                nurseService.EditeNurse(nurse);
                return RedirectToAction("Index");
            }
            ViewBag.listShift = nurseService.GetListShift();

            return View();
        }
        [HttpGet]
        public IActionResult DetailsNurse(int id)
        {
            var Nurse = nurseService.GetNurseById(id);
            return View(Nurse);

        }
        [HttpGet]
        public IActionResult DeleteNurse(Nurse Nurse)
        {
           
            nurseService.DeleteNurse(Nurse);
            return RedirectToAction("Index");

        }

    }
}
