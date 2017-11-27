using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace Absenz
{
    public class StudentRepository : IStudentRepository
    {
        public bool WriteAbsence(StudentAbsence studentAbsence)
        {
            try
            {
                SaveAbsence(studentAbsence);
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public List<StudentAbsence> ReadAll()
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                return db.Query<StudentAbsence>(
                    "SELECT CONCAT(s.nachname, ' ', s.vorname) as 'Student'," +
                    "CONCAT(l.nachname, ' ', l.vorname) as 'Teacher', " +
                    "f.name as 'Subject' , " +
                    "grund as 'Reason', " +
                    "datum as 'Date' " +
                    "FROM absenz_db.absenz a " +
                    "inner join schueler s on s.id_schueler = a.FK_Schueler " +
                    "inner join fach f on f.id_fach = a.FK_Fach " +
                    "inner join lehrperson l on l.id_lehrperson = a.FK_Lehrperson;").ToList();
            }
        }

        private void SaveAbsence(StudentAbsence studentAbsence)
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string sqlQuery = "INSERT INTO absenz(datum, grund, FK_Schueler, FK_Fach, FK_Lehrperson) " +
                                        "VALUES (@Date, @Reason, " +
                                        "(SELECT id_schueler FROM schueler WHERE vorname = @studentFirstname AND nachname = @studentLastname), " +
                                        "(SELECT id_fach FROM fach WHERE name = @Subject)," +
                                        "(SELECT id_lehrperson FROM lehrperson WHERE vorname = @teacherFirstname AND nachname = @teacherLastname))";
                db.Execute(sqlQuery, new
                {
                    studentAbsence.Date,
                    studentAbsence.Reason,
                    studentFirstname = SplitName(studentAbsence.Student)[0],
                    studentLastname = SplitName(studentAbsence.Student)[1],
                    studentAbsence.Subject,
                    teacherFirstname = SplitName(studentAbsence.Teacher)[0],
                    teacherLastname = SplitName(studentAbsence.Teacher)[1]
                });
            }
        }

        public string[] SplitName(string fullName)
        {
            return fullName.Split(' ');
        }
    }
}