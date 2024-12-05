using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Hospital.Models.Enums;

namespace Hospital.services
{
    public class BillingService:IBillingService
    {
        private readonly ApplictionContext Context;
        public BillingService(ApplictionContext applictionContext)
        {
            Context = applictionContext;

        }

        public List<Billing> GetBillingsPatients()
        {
            List<Billing> billing = Context.billings.Include(z=>z.patient).Include(a=>a.Appointment).ToList();
            return billing;
        }
        public SelectList GetlistPatients()
        {
            var listPatients = Context.patients.ToList();
            return new SelectList(listPatients, "Id", "Name");
        }
        public SelectList GetlistAppointments()
        {
            var listAppointments = Context.appointments.ToList();
            return new SelectList(listAppointments, "Id", "Date");
        }

        public Billing GetBillingById(int id)
        {

            return Context?.billings?.Include(a=>a.patient).Include(_=>_.Appointment).FirstOrDefault(_=>_.Id==id)!;
        }
        public SelectList GetListPaymentStatus()
        {
            var PaymentStatus = Enum.GetValues(typeof(PaymentStatus))
                                     .Cast<PaymentStatus>()
                                     .Select(x => new { Id = (int)x, Name = x.ToString() })
                                     .ToList();

            return new SelectList(PaymentStatus, "Id", "Name");
        }



        public void InsertBilling(Billing billing)
        {
            billing.DateGenerated = DateTime.Now;
            Context.Add(billing);
            Context.SaveChanges();
        }
        public void EditeBilling(Billing billing)
        {

            Context.Update(billing);
            Context.SaveChanges();
        }
        public void DeleteBilling(Billing billing)
        {
            var bill = GetBillingById(billing.Id);
          if(bill != null)
            {
                bill.IsActive=!bill.IsActive;
                Context.SaveChanges();
            }
           
        }

    }
}
