namespace Absenz
{
    public class StudentAbsence
    {
        public string Student { get; set; }

        public string Teacher { get; set; }

        public string Subject { get; set; }

        public string Reason { get; set; }

        public string Date { get; set; }

        public StudentAbsence(string student, string teacher, string subject, string reason, string date)
        {
            this.Student = student;
            this.Teacher = teacher;
            this.Subject = subject;
            this.Reason = reason;
            this.Date = date;
        }

    }
}