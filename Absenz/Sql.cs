using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Absenz
{
    public class Sql
    {
        private readonly MySqlConnection _mySqlConnection;
        private MySqlCommand _mySqlCommand;

        public Sql(MySqlConnection mySqlConnection)
        {
            this._mySqlConnection = mySqlConnection;
        }

        public void WriteAbsence(StudentAbsence studentAbsence)
        {
            try
            {
                SaveAbsence(studentAbsence);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<StudentAbsence> GetAbsences()
        {
            var studentAbsence = new List<StudentAbsence>();

            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText = "SELECT a.*, s.nachname as \'Schülernachname\', s.vorname as \'Schülervorname\', l.nachname as \'Lehrernachname\', l.vorname as \'Lehrervorname\', f.name FROM absenz_db.absenz a inner join schueler s on s.id_schueler = a.FK_Schueler inner join fach f on f.id_fach = a.FK_Fach inner join lehrperson l on l.id_lehrperson = a.FK_Lehrperson;";

            using (var reader = _mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        studentAbsence.Add(new StudentAbsence(
                            reader.GetString("Schülervorname") + " " + reader.GetString("Schülernachname"),
                            reader.GetString("Lehrervorname") + " " + reader.GetString("Lehrernachname"), 
                            reader.GetString("name"),
                            reader.GetString("grund"), 
                            reader.GetString("datum"), 
                            reader.GetString("FK_Schueler"),
                            reader.GetString("FK_Lehrperson"), 
                            reader.GetString("FK_Fach"))
                            );
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return studentAbsence;
        }

        private void SaveAbsence(StudentAbsence studentAbsence)
        {
            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText = "INSERT INTO absenz(datum, grund, FK_Schueler, FK_Fach, FK_Lehrperson) VALUES (@date, @reason, @student, @subject, @teacher)";
            _mySqlCommand.Parameters.AddWithValue("@date", studentAbsence.Date);
            _mySqlCommand.Parameters.AddWithValue("@reason", studentAbsence.Reason);
            _mySqlCommand.Parameters.AddWithValue("@student", studentAbsence.StudentId);
            _mySqlCommand.Parameters.AddWithValue("@subject", studentAbsence.SubjectId);
            _mySqlCommand.Parameters.AddWithValue("@teacher", studentAbsence.TeacherId);

            _mySqlCommand.ExecuteNonQuery();
        }

        public string GetStudentIdByName(string studentName)
        {
            return GetStudentIdSql(SplitName(studentName));
        }

        public string GetTeacherIdByName(string teacherName)
        {
            return GetTeacherIdSql(SplitName(teacherName));
        }

        public string GetSubjectIdByName(string subject)
        {
            return GetSubjectIdSql(subject);
        }

        
        private string GetStudentIdSql(string[] studentName)
        {
            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText = "SELECT id_schueler FROM schueler WHERE vorname = @firstname AND nachname = @lastname";
            _mySqlCommand.Parameters.AddWithValue("@firstname", studentName[0]);
            _mySqlCommand.Parameters.AddWithValue("@lastname", studentName[1]);

            using (var reader = _mySqlCommand.ExecuteReader())
            {
                return reader.Read() ? reader.GetString(0) : "0";
            }
        }
        
        private string GetTeacherIdSql(string[] teacherName)
        {
            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText = "SELECT id_lehrperson FROM lehrperson WHERE vorname = @firstname AND nachname = @lastname";
            _mySqlCommand.Parameters.AddWithValue("@firstname", teacherName[0]);
            _mySqlCommand.Parameters.AddWithValue("@lastname", teacherName[1]);

            using (var reader = _mySqlCommand.ExecuteReader())
            {
                return reader.Read() ? reader.GetString(0) : "0";
            }
        }
        
        private string GetSubjectIdSql(string subject)
        {
            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText = "SELECT id_fach FROM fach WHERE name = @fach";
            _mySqlCommand.Parameters.AddWithValue("@fach", subject);

            using (var reader = _mySqlCommand.ExecuteReader())
            {
                return reader.Read() ? reader.GetString(0) : "0";
            }
        }
        
        public string[] SplitName(string fullName)
        {
            return fullName.Split(' ');
        }
    }
}