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
    public partial class LectureReg : Form
    {
        public LectureReg()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox14_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Lectures01 LeC = new Lectures01();
            LeC.Show();
            this.Hide();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(bunifuMaterialTextbox12.Text);
            string Name = bunifuMaterialTextbox1.Text;
            string NIC = bunifuMaterialTextbox10.Text;
            
            string DOBDate = Convert.ToString(bunifuDropdown1.selectedIndex + 1);

            string DOBMonth = "";
            if (bunifuDropdown2.selectedIndex == 0)
            {
                DOBMonth = "January";
            }
            else if (bunifuDropdown2.selectedIndex == 1)
            {
                DOBMonth = "February";
            }
            else if (bunifuDropdown2.selectedIndex == 2)
            {
                DOBMonth = "March";
            }
            else if (bunifuDropdown2.selectedIndex == 3)
            {
                DOBMonth = "April";
            }
            else if (bunifuDropdown2.selectedIndex == 4)
            {
                DOBMonth = "May";
            }
            else if (bunifuDropdown2.selectedIndex == 5)
            {
                DOBMonth = "June";
            }
            else if (bunifuDropdown2.selectedIndex == 6)
            {
                DOBMonth = "July";
            }
            else if (bunifuDropdown2.selectedIndex == 7)
            {
                DOBMonth = "August";
            }
            else if (bunifuDropdown2.selectedIndex == 8)
            {
                DOBMonth = "September";
            }
            else if (bunifuDropdown2.selectedIndex == 9)
            {
                DOBMonth = "October";
            }
            else if (bunifuDropdown2.selectedIndex == 10)
            {
                DOBMonth = "November";
            }
            else
            {
                DOBMonth = "December";
            }

            string DOBYear = Convert.ToString(2020 - bunifuDropdown3.selectedIndex + 1);
            string MobileNumber = bunifuMaterialTextbox4.Text;
            string EmailAddress = bunifuMaterialTextbox3.Text;
            string Address = bunifuMaterialTextbox5.Text;
            string AcademicQualifications = bunifuMaterialTextbox11.Text;
            string ProfessionalQualifications = bunifuMaterialTextbox13.Text;

            string qry = "INSERT INTO Lecturer Values (" + ID + ",'" + Name + "','" + NIC + "','" + DOBDate + "','" + DOBMonth + "','" + DOBYear + "','" + MobileNumber + "','" + EmailAddress + "','" + Address + "','" + AcademicQualifications + "','" + ProfessionalQualifications + "')";
            DBConnection dbc = new DBConnection();
            string feedback = dbc.DBCon(qry);

            MessageBox.Show(feedback);
        }
    }
}
