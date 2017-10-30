namespace Absenz
{
    public class StudentAbsence
    {
        public string Student { get; set; }

        public string Teacher { get; set; }

        public string Subject { get; set; }

        public string Reason { get; set; }

        public string Date { get; set; }

        public string StudentId { get; set; }

        public string TeacherId { get; set; }

        public string SubjectId { get; set; }

        public StudentAbsence(string student, string teacher, string subject, string reason, string date, string studentId, string teacherId, string subjectId)
        {
            this.Student = student;
            this.Teacher = teacher;
            this.Subject = subject;
            this.Reason = reason;
            this.Date = date;
            this.StudentId = studentId;
            this.TeacherId = teacherId;
            this.SubjectId = subjectId;
        }
    }
}