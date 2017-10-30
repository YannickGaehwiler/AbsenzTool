using System;
using System.Drawing;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Absenz
{
    public partial class Form1 : MaterialForm
    {
        private DatabaseConnection _dbCon;
        private StudentAbsence _studentAbsence;
        private readonly Sql _sqlManager;
        public Form1()
        {
            MaximizeBox = false;

            InitializeComponent();
            ActivateMaterialDesign();
            EstablishDbConnection();

            _sqlManager = new Sql(_dbCon.Con);

            PrintAbsence();
        }

        private void ActivateMaterialDesign()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void PrintAbsence()
        {
            foreach (var absence in _sqlManager.GetAbsences())
            {
                var absenceList = new System.Windows.Forms.ListViewItem(new[]
                {
                    absence.Student,
                    absence.Teacher,
                    absence.Subject,
                    absence.Date,
                    absence.Reason
                }, -1);
                absenceListView.Items.AddRange(new[] {absenceList});
            }
        }

        private void EstablishDbConnection()
        {
            this._dbCon = new DatabaseConnection("localhost", "absenz_db", "root", "Test1234");
            this._dbCon.Connect();
        }

        private void SaveAbsenceButton_Click(object sender, EventArgs e)
        {
            _studentAbsence = new StudentAbsence(studentTextField.Text, teacherTextField.Text, subjectTextField.Text, reasonTextField.Text, dateTextField.Text, _sqlManager.GetStudentIdByName(studentTextField.Text), _sqlManager.GetTeacherIdByName(teacherTextField.Text), _sqlManager.GetSubjectIdByName(subjectTextField.Text));
            _sqlManager.WriteAbsence(_studentAbsence);
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            studentTextField.Text = null;
            teacherTextField.Text = null;
            reasonTextField.Text = null;
            subjectTextField.Text = null;
            dateTextField.Text = null;
        }
    }
}
