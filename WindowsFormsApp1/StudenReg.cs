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
    public partial class StudenReg : Form
    {
        public StudenReg()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown3_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox9_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox8_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Students01 st = new Students01();
            st.Show();
            this.Hide();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Students01 st = new Students01();
            st.Show();
            this.Hide();
        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(bunifuMaterialTextbox12.Text);
            string Name = bunifuMaterialTextbox1.Text;
            string NIC = bunifuMaterialTextbox10.Text;
            int MobileNumber = int.Parse(bunifuMaterialTextbox4.Text);
            string DOBDate = Convert.ToString(bunifuDropdown1.selectedIndex+1);

            string DOBMonth = "";
            if(bunifuDropdown2.selectedIndex==0)
            {
                DOBMonth = "January";
            }
            else if(bunifuDropdown2.selectedIndex == 1)
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

            string DOBYear = Convert.ToString(2020-bunifuDropdown3.selectedIndex+1);

            string EmailAddress = bunifuMaterialTextbox3.Text;
            string Address = bunifuMaterialTextbox5.Text;
            string OLMath = bunifuMetroTextbox2.Text;
            string OLEnglish = bunifuMetroTextbox1.Text;
            string ALEnglish = bunifuMetroTextbox3.Text;
            string ALIT = bunifuMetroTextbox4.Text;
            string Degree = bunifuMaterialTextbox11.Text;
            string Year = ""; 
            if(bunifuDropdown5.selectedIndex==0)
            {
                Year = "Year 1";
            }
            else if(bunifuDropdown5.selectedIndex == 1)
            {
                Year = "Year 2";
            }
            else if(bunifuDropdown5.selectedIndex == 2)
            {
                Year = "Year 3";
            }
            else
            {
                Year = "Year 4";
            }

            string Semester = "";    
            if(bunifuDropdown4.selectedIndex == 0)
            {
                Semester = "Semester 01";
            }

            else if(bunifuDropdown4.selectedIndex == 1)
            {
                Semester = "Semester 02";
            }

            else
            {
                Semester = "Semester 03";
            }

            string qry = "INSERT INTO Student Values ("+ID+",'"+Name+"','"+NIC+"','"+DOBDate+"','"+DOBMonth+"','"+DOBYear+"',"+MobileNumber+",'"+EmailAddress+"','"+Address+"','"+OLMath+ "','" + OLEnglish + "','" + ALEnglish + "','" + ALIT + "','" + Degree + "','" + Year + "','" + Semester + "')";
            DBConnection dbc = new DBConnection();
            string feedback = dbc.DBCon(qry);

            MessageBox.Show(feedback);
        }
    }
}
