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
    public partial class ReserchProj : Form
    {
        public ReserchProj()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Project01 Pro = new Project01();
            Pro.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int ProjectID = int.Parse(bunifuMaterialTextbox1.Text);
            string ProjectName = bunifuMaterialTextbox2.Text;
            string Area = bunifuMaterialTextbox4.Text;
            string Description = bunifuMaterialTextbox7.Text;
            string Duration = bunifuMaterialTextbox9.Text;

            string Status = "";
            if(bunifuDropdown3.selectedIndex == 0)
            {
                Status = "Approved";
            }
            else if(bunifuDropdown3.selectedIndex == 1)
            {
                Status = "Declined";
            }
            else
            {
                Status = "Approval Pending";
            }

            string Supervisors = bunifuMaterialTextbox10.Text;
            string StudentName = bunifuMaterialTextbox6.Text;
            int StudentID = int.Parse(bunifuMaterialTextbox8.Text);

            string qry = "INSERT INTO ResearchProjects Values (" + ProjectID + ",'" + ProjectName + "','" + Area + "','" + Description + "','" + Duration + "','" +Status+ "','" + Supervisors + "','" + StudentName + "'," + StudentID + ")";
            DBConnection dbc = new DBConnection();
            string feedback = dbc.DBCon(qry);

            MessageBox.Show(feedback);

        }
    }
}
