using System;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Absenz
{
    public partial class Form1 : MaterialForm
    {
        private StudentAbsence _studentAbsence;
        private readonly IStudentRepository _studentRepository;
        public Form1()
        {
            MaximizeBox = false;

            InitializeComponent();
            ActivateMaterialDesign();

            _studentRepository = new StudentRepository();

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
            foreach (var absence in _studentRepository.ReadAll())
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

        private void SaveAbsenceButton_Click(object sender, EventArgs e)
        {
            _studentAbsence = new StudentAbsence(studentTextField.Text, teacherTextField.Text, subjectTextField.Text, reasonTextField.Text, dateTextField.Text);
            _studentRepository.WriteAbsence(_studentAbsence);
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
