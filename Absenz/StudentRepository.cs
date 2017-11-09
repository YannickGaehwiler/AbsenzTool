﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Absenz
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MySqlConnection _mySqlConnection;
        private MySqlCommand _mySqlCommand;

        public StudentRepository(MySqlConnection mySqlConnection)
        {
            this._mySqlConnection = mySqlConnection;
        }
        
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
                        studentAbsence.Add(new StudentAbsence(reader.GetString("Schülervorname") + " " + reader.GetString("Schülernachname"),reader.GetString("Lehrervorname") + " " + reader.GetString("Lehrernachname"), reader.GetString("name"), reader.GetString("grund"), reader.GetString("datum")));
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
            _mySqlCommand.CommandText = "INSERT INTO absenz(datum, grund, FK_Schueler, FK_Fach, FK_Lehrperson) VALUES (@date, @reason, (SELECT id_schueler FROM schueler WHERE vorname = @studentFirstname AND nachname = @studentLastname), (SELECT id_fach FROM fach WHERE name = @fach), (SELECT id_lehrperson FROM lehrperson WHERE vorname = @teacherFirstname AND nachname = @TeacherLastname))";
            _mySqlCommand.Parameters.AddWithValue("@date", studentAbsence.Date);
            _mySqlCommand.Parameters.AddWithValue("@reason", studentAbsence.Reason);
            _mySqlCommand.Parameters.AddWithValue("@studentFirstname", SplitName(studentAbsence.Student)[0]);
            _mySqlCommand.Parameters.AddWithValue("@studentLastname", SplitName(studentAbsence.Student)[1]);
            _mySqlCommand.Parameters.AddWithValue("@fach", studentAbsence.Subject);
            _mySqlCommand.Parameters.AddWithValue("@teacherFirstname", SplitName(studentAbsence.Teacher)[0]);
            _mySqlCommand.Parameters.AddWithValue("@teacherLastname", SplitName(studentAbsence.Teacher)[1]);

            _mySqlCommand.ExecuteNonQuery();
        }
        
        public string[] SplitName(string fullName)
        {
            return fullName.Split(' ');
        }
    }
}