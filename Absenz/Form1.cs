using System;
using System.Drawing;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Absenz
{
    public partial class Form1 : MaterialForm
    {
        private Absence _absence;
        private DatabaseConnection _dbCon;
        public Form1()
        {
            MaximizeBox = false;

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            EstablishDbConnection();

            _absence = new Absence(_dbCon.Con);
            _absence.ShowAbsence();

            PrintAbsence();
        }

        private void PrintAbsence()
        {
            foreach (var absence in _absence.ShowAbsence())
            {
                System.Windows.Forms.ListViewItem absenceList = new System.Windows.Forms.ListViewItem(new[]
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
            _absence = new Absence(studentTextField.Text, dateTextField.Text, teacherTextField.Text, subjectTextField.Text, reasonTextField.Text, officeTextField.Text, _dbCon.Con);
            _absence.SaveAbsence();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
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
