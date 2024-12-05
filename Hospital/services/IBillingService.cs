using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.services
{
    public interface IBillingService
    {
        List<Billing> GetBillingsPatients();
        Billing GetBillingById(int id);
        void InsertBilling(Billing billing);
        void EditeBilling(Billing billing);
        void DeleteBilling(Billing billing);
        SelectList GetlistPatients();
        SelectList GetListPaymentStatus();
        SelectList GetlistAppointments();


    }
}
