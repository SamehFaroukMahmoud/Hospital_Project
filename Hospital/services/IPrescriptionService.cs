using Hospital.Models;

namespace Hospital.services
{
    public interface IPrescriptionService
    {
        List<Prescription> GetPrescriptions();
        Prescription GetPrescriptionId(int id);
        void InsertPrescription(Prescription prescription);
        void UpdatePrescription(Prescription prescription);
        void DeletePrescription(Prescription prescription);
    }
}
