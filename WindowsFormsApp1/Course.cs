using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Course : Form
    {
        public Course()
        {
            InitializeComponent();
        }

        private void Course_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Course01 curs1 = new Course01();
            curs1.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int CourseID = int.Parse(bunifuMaterialTextbox1.Text);
            string CourseCode = bunifuMaterialTextbox4.Text;
            string CourseName = bunifuMaterialTextbox2.Text;
            string NoOfCredits = bunifuMaterialTextbox8.Text;
            string NoOfUnits = bunifuMaterialTextbox10.Text;
            float CourseFee = float.Parse(bunifuMaterialTextbox11.Text);
            int LecturerID = int.Parse(bunifuMaterialTextbox9.Text);
            string LecturerName = bunifuMaterialTextbox7.Text;
            string Description = bunifuMaterialTextbox5.Text;

            string qry = "INSERT INTO Course Values (" + CourseID + ",'" + CourseCode + "','" + CourseName + "','" + NoOfCredits + "','" + NoOfUnits + "'," + CourseFee + "," + LecturerID + ",'" + LecturerName + "', '"+Description+"')";

            DBConnection dbc = new DBConnection();
            string feedback = dbc.DBCon(qry);

            MessageBox.Show(feedback);
        }
    }
}
