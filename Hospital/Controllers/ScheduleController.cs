using Hospital.Models;
using Hospital.services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService ScheduleService; IMedicalRecordService MedicalRecordService;
        public ScheduleController(IScheduleService Schedule, IMedicalRecordService medicalRecordService)
        {
            ScheduleService = Schedule;
            MedicalRecordService= medicalRecordService;
        }
        public IActionResult Index()
        {
            List<Schedule> Schedules = ScheduleService.GetSchedules();
            return View(Schedules);
        }
        [HttpGet]
        public IActionResult CreateSchedule()
        {
            ViewBag.DayOfWeek = ScheduleService.GetDayOfWeek();
            ViewBag.GetListOfDoctor = MedicalRecordService.GetListDoctor();
            return View();
        }
        [HttpPost]
        public IActionResult CreateSchedule(Schedule Schedule)
        {
            ViewBag.DayOfWeek = ScheduleService.GetDayOfWeek();
            ViewBag.GetListOfDoctor = MedicalRecordService.GetListDoctor();
            ScheduleService.InsertSchedule(Schedule);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditeSchedule(int id)
        {
            ViewBag.DayOfWeek = ScheduleService.GetDayOfWeek();
            ViewBag.GetListOfDoctor = MedicalRecordService.GetListDoctor();

            var Schedule = ScheduleService.GetScheduleById(id);
            return View(Schedule);
        }
        [HttpPost]
        public IActionResult EditeSchedule(Schedule Schedule)
        {
            ViewBag.DayOfWeek = ScheduleService.GetDayOfWeek();
            ViewBag.GetListOfDoctor = MedicalRecordService.GetListDoctor();
            ScheduleService.EditeSchedule(Schedule);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DetailsSchedule(int id)
        {
            ViewBag.DayOfWeek = ScheduleService.GetDayOfWeek();

            var Schedule = ScheduleService.GetScheduleById(id);
            return View(Schedule);

        }
        [HttpGet]
        public IActionResult DeleteSchedule(Schedule Schedule)
        {
            ScheduleService.DeleteSchedule(Schedule);
            return RedirectToAction("Index");

        }

    }
}
