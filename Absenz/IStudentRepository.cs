using System.Collections.Generic;

namespace Absenz
{
    public interface IStudentRepository
    {
        string[] SplitName(string fullName);
        bool WriteAbsence(StudentAbsence studentAbsence);
        List<StudentAbsence> ReadAll();
    }
}