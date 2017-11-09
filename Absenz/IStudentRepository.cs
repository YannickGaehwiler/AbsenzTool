using System;
using System.Collections.Generic;

namespace Absenz
{
    public interface IStudentRepository
    {
        List<StudentAbsence> GetAbsences();
        string[] SplitName(string fullName);
        bool WriteAbsence(StudentAbsence studentAbsence);
    }
}