using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Absenz
{
    public class Absence
    {
        private readonly SqlManager _sqlManager;

        public Absence(string student, string date, string teacher, string subject, string reason, string office, MySqlConnection mySqlConnection)
        {
            var studentName = student.Split(' ');
            var teacherName = teacher.Split(' ');

            _sqlManager = new SqlManager(studentName, date, teacherName, subject, reason, office, mySqlConnection);
        }

        public Absence(MySqlConnection mySqlConnection)
        {
            _sqlManager = new SqlManager(mySqlConnection);
        }

        public void SaveAbsence()
        {
            try
            {
               _sqlManager.WriteAbsence();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void ShowAbsence()
        {
            _sqlManager.GetAbsence();
        }
    }
}
