using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.services
{
    public interface INurseService
    {
        List<Nurse> GetNurse(string? search);
        Nurse GetNurseById(int id);
        void InsertNurse(Nurse nurse);
        void EditeNurse(Nurse nurse);
        void DeleteNurse(Nurse nurse);
        SelectList GetListShift();
    }
}
