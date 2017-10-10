using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Absenz
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private int currentDay = DateTime.Now.Day;
        private int currentMonth = DateTime.Now.Month;
        private int currentYear = DateTime.Now.Year;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.messageLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.saveAbsenceButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.officeTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.officeLabel = new MaterialSkin.Controls.MaterialLabel();
            this.reasonTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.reasonLabel = new MaterialSkin.Controls.MaterialLabel();
            this.subjectTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.subjectLabel = new MaterialSkin.Controls.MaterialLabel();
            this.teacherTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.teacherLabel = new MaterialSkin.Controls.MaterialLabel();
            this.dateTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.dateLabel = new MaterialSkin.Controls.MaterialLabel();
            this.studentTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.studentLabel = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 64);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(620, 40);
            this.materialTabSelector1.TabIndex = 0;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(12, 110);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(596, 262);
            this.materialTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.materialListView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(588, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Absenzen anzeigen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.messageLabel);
            this.tabPage2.Controls.Add(this.materialRaisedButton2);
            this.tabPage2.Controls.Add(this.saveAbsenceButton);
            this.tabPage2.Controls.Add(this.officeTextField);
            this.tabPage2.Controls.Add(this.officeLabel);
            this.tabPage2.Controls.Add(this.reasonTextField);
            this.tabPage2.Controls.Add(this.reasonLabel);
            this.tabPage2.Controls.Add(this.subjectTextField);
            this.tabPage2.Controls.Add(this.subjectLabel);
            this.tabPage2.Controls.Add(this.teacherTextField);
            this.tabPage2.Controls.Add(this.teacherLabel);
            this.tabPage2.Controls.Add(this.dateTextField);
            this.tabPage2.Controls.Add(this.dateLabel);
            this.tabPage2.Controls.Add(this.studentTextField);
            this.tabPage2.Controls.Add(this.studentLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(588, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Absenzen erfassen";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Depth = 0;
            this.messageLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.messageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.messageLabel.Location = new System.Drawing.Point(353, 214);
            this.messageLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 19);
            this.messageLabel.TabIndex = 14;
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(342, 177);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(150, 35);
            this.materialRaisedButton2.TabIndex = 13;
            this.materialRaisedButton2.Text = "Löschen";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // saveAbsenceButton
            // 
            this.saveAbsenceButton.Depth = 0;
            this.saveAbsenceButton.Location = new System.Drawing.Point(432, 177);
            this.saveAbsenceButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveAbsenceButton.Name = "saveAbsenceButton";
            this.saveAbsenceButton.Primary = true;
            this.saveAbsenceButton.Size = new System.Drawing.Size(150, 35);
            this.saveAbsenceButton.TabIndex = 12;
            this.saveAbsenceButton.Text = "Absenz erfassen";
            this.saveAbsenceButton.UseVisualStyleBackColor = true;
            this.saveAbsenceButton.Click += new System.EventHandler(this.SaveAbsenceButton_Click);
            // 
            // officeTextField
            // 
            this.officeTextField.Depth = 0;
            this.officeTextField.Hint = "";
            this.officeTextField.Location = new System.Drawing.Point(96, 119);
            this.officeTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.officeTextField.Name = "officeTextField";
            this.officeTextField.PasswordChar = '\0';
            this.officeTextField.SelectedText = "";
            this.officeTextField.SelectionLength = 0;
            this.officeTextField.SelectionStart = 0;
            this.officeTextField.Size = new System.Drawing.Size(222, 23);
            this.officeTextField.TabIndex = 11;
            this.officeTextField.UseSystemPasswordChar = false;
            // 
            // officeLabel
            // 
            this.officeLabel.AutoSize = true;
            this.officeLabel.Depth = 0;
            this.officeLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.officeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.officeLabel.Location = new System.Drawing.Point(6, 118);
            this.officeLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.officeLabel.Name = "officeLabel";
            this.officeLabel.Size = new System.Drawing.Size(82, 19);
            this.officeLabel.TabIndex = 10;
            this.officeLabel.Text = "Sekretariat";
            // 
            // reasonTextField
            // 
            this.reasonTextField.Depth = 0;
            this.reasonTextField.Hint = "";
            this.reasonTextField.Location = new System.Drawing.Point(66, 80);
            this.reasonTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.reasonTextField.Name = "reasonTextField";
            this.reasonTextField.PasswordChar = '\0';
            this.reasonTextField.SelectedText = "";
            this.reasonTextField.SelectionLength = 0;
            this.reasonTextField.SelectionStart = 0;
            this.reasonTextField.Size = new System.Drawing.Size(506, 23);
            this.reasonTextField.TabIndex = 9;
            this.reasonTextField.UseSystemPasswordChar = false;
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Depth = 0;
            this.reasonLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.reasonLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.reasonLabel.Location = new System.Drawing.Point(6, 79);
            this.reasonLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(48, 19);
            this.reasonLabel.TabIndex = 8;
            this.reasonLabel.Text = "Grund";
            // 
            // subjectTextField
            // 
            this.subjectTextField.Depth = 0;
            this.subjectTextField.Hint = "";
            this.subjectTextField.Location = new System.Drawing.Point(359, 42);
            this.subjectTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.subjectTextField.Name = "subjectTextField";
            this.subjectTextField.PasswordChar = '\0';
            this.subjectTextField.SelectedText = "";
            this.subjectTextField.SelectionLength = 0;
            this.subjectTextField.SelectionStart = 0;
            this.subjectTextField.Size = new System.Drawing.Size(213, 23);
            this.subjectTextField.TabIndex = 7;
            this.subjectTextField.UseSystemPasswordChar = false;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Depth = 0;
            this.subjectLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.subjectLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.subjectLabel.Location = new System.Drawing.Point(298, 41);
            this.subjectLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(41, 19);
            this.subjectLabel.TabIndex = 6;
            this.subjectLabel.Text = "Fach";
            // 
            // teacherTextField
            // 
            this.teacherTextField.Depth = 0;
            this.teacherTextField.Hint = "";
            this.teacherTextField.Location = new System.Drawing.Point(98, 41);
            this.teacherTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.teacherTextField.Name = "teacherTextField";
            this.teacherTextField.PasswordChar = '\0';
            this.teacherTextField.SelectedText = "";
            this.teacherTextField.SelectionLength = 0;
            this.teacherTextField.SelectionStart = 0;
            this.teacherTextField.Size = new System.Drawing.Size(175, 23);
            this.teacherTextField.TabIndex = 5;
            this.teacherTextField.UseSystemPasswordChar = false;
            // 
            // teacherLabel
            // 
            this.teacherLabel.AutoSize = true;
            this.teacherLabel.Depth = 0;
            this.teacherLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.teacherLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.teacherLabel.Location = new System.Drawing.Point(6, 40);
            this.teacherLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.teacherLabel.Name = "teacherLabel";
            this.teacherLabel.Size = new System.Drawing.Size(84, 19);
            this.teacherLabel.TabIndex = 4;
            this.teacherLabel.Text = "Lehrperson";
            // 
            // dateTextField
            // 
            this.dateTextField.Depth = 0;
            this.dateTextField.Hint = "";
            this.dateTextField.Location = new System.Drawing.Point(360, 4);
            this.dateTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.dateTextField.Name = "dateTextField";
            this.dateTextField.PasswordChar = '\0';
            this.dateTextField.SelectedText = "";
            this.dateTextField.SelectionLength = 0;
            this.dateTextField.SelectionStart = 0;
            this.dateTextField.Size = new System.Drawing.Size(212, 23);
            this.dateTextField.TabIndex = 3;
            this.dateTextField.UseSystemPasswordChar = false;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Depth = 0;
            this.dateLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dateLabel.Location = new System.Drawing.Point(298, 3);
            this.dateLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(53, 19);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Datum";
            // 
            // studentTextField
            // 
            this.studentTextField.Depth = 0;
            this.studentTextField.Hint = "";
            this.studentTextField.Location = new System.Drawing.Point(73, 4);
            this.studentTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.studentTextField.Name = "studentTextField";
            this.studentTextField.PasswordChar = '\0';
            this.studentTextField.SelectedText = "";
            this.studentTextField.SelectionLength = 0;
            this.studentTextField.SelectionStart = 0;
            this.studentTextField.Size = new System.Drawing.Size(200, 23);
            this.studentTextField.TabIndex = 1;
            this.studentTextField.UseSystemPasswordChar = false;
            // 
            // studentLabel
            // 
            this.studentLabel.AutoSize = true;
            this.studentLabel.Depth = 0;
            this.studentLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.studentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.studentLabel.Location = new System.Drawing.Point(6, 3);
            this.studentLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.studentLabel.Name = "studentLabel";
            this.studentLabel.Size = new System.Drawing.Size(59, 19);
            this.studentLabel.TabIndex = 0;
            this.studentLabel.Text = "Schüler";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(588, 236);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Absenzen bestätigen";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // materialListView1
            // 
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.materialListView1.Depth = 0;
            this.materialListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.materialListView1.FullRowSelect = true;
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            this.materialListView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.materialListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.materialListView1.Location = new System.Drawing.Point(3, 9);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.Size = new System.Drawing.Size(579, 224);
            this.materialListView1.TabIndex = 0;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Schüler";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Lehrer";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fach";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Datum";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Grund";
            this.columnHeader5.Width = 110;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 371);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Name = "Form1";
            this.Text = "Absenz Tool";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialLabel studentLabel;
        public MaterialSkin.Controls.MaterialSingleLineTextField studentTextField;
        public MaterialSkin.Controls.MaterialSingleLineTextField dateTextField;
        private MaterialSkin.Controls.MaterialLabel dateLabel;
        private MaterialSkin.Controls.MaterialLabel teacherLabel;
        public MaterialSkin.Controls.MaterialSingleLineTextField teacherTextField;
        public MaterialSkin.Controls.MaterialSingleLineTextField subjectTextField;
        private MaterialSkin.Controls.MaterialLabel subjectLabel;
        public MaterialSkin.Controls.MaterialSingleLineTextField officeTextField;
        private MaterialSkin.Controls.MaterialLabel officeLabel;
        public MaterialSkin.Controls.MaterialSingleLineTextField reasonTextField;
        private MaterialSkin.Controls.MaterialLabel reasonLabel;
        private MaterialSkin.Controls.MaterialRaisedButton saveAbsenceButton;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        public MaterialSkin.Controls.MaterialLabel messageLabel;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
    }
}

