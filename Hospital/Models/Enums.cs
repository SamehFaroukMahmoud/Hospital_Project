namespace Hospital.Models
{
    public class Enums
    {
        public enum Gender

        {
            Male,
            Female,        
            Other
        }
        public enum Specialization

        {
            Cardiology=1,
            Neurology,
            EyeSurgery

        }
        public enum Shift

        {
            Morning, 
            Afternoon,
            Night

        }
        public enum Statusenum

        {
            Scheduled, 
            Completed, 
            Canceled

        }
        public enum PaymentStatus

        {
            Pending,
            Paid,
            Overdue
        }
        public enum DayOfWeek

        {
            Saturday=1,
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
           
        }


    }

}
