using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Absenz
{
    public class SqlManager
    {
        private int _studentId;
        private int _teacherId;
        private int _subjectId;

        private readonly string[] _studentName;
        private readonly string _date;
        private readonly string[] _teacherName;
        private readonly string _subject;
        private readonly string _reason;
        private string _office;

        private readonly MySqlConnection _mySqlConnection;
        private MySqlCommand _mySqlCommand;

        public SqlManager(string[] studentName, string date, string[] teacherName, string subject, string reason, string office, MySqlConnection mySqlConnection)
        {
            this._studentName = studentName;
            this._date = date;
            this._teacherName = teacherName;
            this._subject = subject;
            this._reason = reason;
            this._office = office;

            this._mySqlConnection = mySqlConnection;
        }

        public SqlManager(MySqlConnection mySqlConnection)
        {
            this._mySqlConnection = mySqlConnection;
        }

        public void WriteAbsence()
        {
            try
            {
                GetStudentId();
                GetTeacherId();
                GetSubjectId();
                SqlCommandSaveAbsence();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<StudentAbsence> GetAbsence()
        {
            var studentAbsence = new List<StudentAbsence>();

            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText = "SELECT * FROM absenz";

            var reader = _mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    studentAbsence.Add(new StudentAbsence(reader.GetString("FK_Schueler"), reader.GetString("FK_Lehrperson"), reader.GetString("FK_Fach"), reader.GetString("grund"), reader.GetString("datum")));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            reader.Close();

            return studentAbsence;
        }

        private void GetStudentId()
        {
            SqlCommandGetStudentId();
        }

        private void GetTeacherId()
        {
            SqlCommandGetTeacherId();
        }

        private void GetSubjectId()
        {
            SqlCommandGetSubjectId();
        }

        private void SqlCommandGetSubjectId()
        {
            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText = "SELECT id_fach FROM fach WHERE name = @fach";
            _mySqlCommand.Parameters.AddWithValue("@fach", _subject);

            var reader = _mySqlCommand.ExecuteReader();

            if (reader.Read())
            {
                this._subjectId = reader.GetInt32(0);
            }
            else
            {
                Console.WriteLine("Fach nicht gefunden");
            }
            reader.Close();
        }

        private void SqlCommandSaveAbsence()
        {
            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText = "INSERT INTO absenz(datum, grund, FK_Schueler, FK_Fach, FK_Lehrperson) VALUES (@date, @reason, @student, @subject, @teacher)";
            _mySqlCommand.Parameters.AddWithValue("@date", _date);
            _mySqlCommand.Parameters.AddWithValue("@reason", _reason);
            _mySqlCommand.Parameters.AddWithValue("@student", _studentId);
            _mySqlCommand.Parameters.AddWithValue("@subject", _subjectId);
            _mySqlCommand.Parameters.AddWithValue("@teacher", _teacherId);

            _mySqlCommand.ExecuteNonQuery();
        }

        private void SqlCommandGetTeacherId()
        {
            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText =
                "SELECT id_lehrperson FROM lehrperson WHERE vorname = @firstname AND nachname = @lastname";
            _mySqlCommand.Parameters.AddWithValue("@firstname", _teacherName[0]);
            _mySqlCommand.Parameters.AddWithValue("@lastname", _teacherName[1]);

            var reader = _mySqlCommand.ExecuteReader();

            if (reader.Read())
            {
                this._teacherId = reader.GetInt32(0);
            }
            else
            {
                Console.WriteLine("Lehrer nicht gefunden");
            }
            reader.Close();
        }

        private void SqlCommandGetStudentId()
        {
            _mySqlCommand = _mySqlConnection.CreateCommand();
            _mySqlCommand.CommandText = "SELECT id_schueler FROM schueler WHERE vorname = @firstname AND nachname = @lastname";
            _mySqlCommand.Parameters.AddWithValue("@firstname", _studentName[0]);
            _mySqlCommand.Parameters.AddWithValue("@lastname", _studentName[1]);

            var reader = _mySqlCommand.ExecuteReader();

            if (reader.Read())
            {
                this._studentId = reader.GetInt32(0);
            }
            else
            {
                Console.WriteLine("Schüler nicht gefunden");
            }
            reader.Close();
        }
    }
}