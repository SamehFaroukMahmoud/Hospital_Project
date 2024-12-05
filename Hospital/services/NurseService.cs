using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Hospital.Models.Enums;

namespace Hospital.services
{
    public class NurseService:INurseService
    {
        private readonly ApplictionContext Context;
        public NurseService(ApplictionContext applictionContext)
        {
            Context = applictionContext;

        }

        public List<Nurse> GetNurse(string?search)
        {
            if (search == null)
            {
                List<Nurse> nurses = Context.nurses.ToList();
                return nurses;
            }
            List<Nurse> nurse = Context.nurses.Where(x=>x.Name.Contains(search)).ToList();
            return nurse;
        }
        public Nurse GetNurseById(int id)
        {

            return Context?.nurses?.Find(id)!;
        }
        public void InsertNurse(Nurse nurse)
        {

            Context.Add(nurse);
            Context.SaveChanges();
        }
        public void EditeNurse(Nurse nurse)
        {

            Context.Update(nurse);
            Context.SaveChanges();
        }
        public void DeleteNurse(Nurse nurse)
        {
            var Nurses = GetNurseById(nurse.Id);
            if(Nurses!=null)
            {
                Nurses.IsActive = !Nurses.IsActive;
                Context.SaveChanges();
            }
        
        }
        public SelectList GetListShift()
        {
            var Shift = Enum.GetValues(typeof(Shift))
                                      .Cast<Shift>()
                                      .Select(x => new { Id = (int)x, Name = x.ToString() })
                                      .ToList();

            return new SelectList(Shift, "Id", "Name");
        }

    }
}
