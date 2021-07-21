using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class ResitRegis : Form
    {
        DatabaseConnection dbc = new DatabaseConnection();
        public ResitRegis()
        {
            InitializeComponent();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit?", "CONFIRM EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Activate();
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Exam01 Ex1 = new Exam01();
            Ex1.Show();
            this.Hide();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(dbc.ConString());
            con.Open();

            if (bunifuMaterialTextbox3.Text != "") 
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Name, EmailAddress, MobileNumber, Degree, Year, Semester from Student where ID = @ID", con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(bunifuMaterialTextbox3.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    bunifuMaterialTextbox1.Text = da.GetValue(1).ToString();
                    bunifuMaterialTextbox4.Text = da.GetValue(2).ToString();
                    bunifuMaterialTextbox5.Text = da.GetValue(3).ToString();
                    bunifuMaterialTextbox2.Text = da.GetValue(4).ToString();


                    string years = da.GetValue(5).ToString();
                    string sem = da.GetValue(6).ToString();
                    int yearNum = 0, semNum = 0;

                    if (years == "Year 1              ")
                    {
                        yearNum = 0;
                    }
                    else if (years == "Year 2              ")
                    {
                        yearNum = 1;
                    }
                    else if (years == "Year 3              ")
                    {
                        yearNum = 2;

                    }
                    else
                    {
                        yearNum = 3;
                    }

                    if (sem == "Semester 01         ")
                    {
                        semNum = 0;
                    }
                    else if (sem == "Semester 02         ")
                    {
                        semNum = 1;
                    }
                    else
                    {
                        semNum = 2;
                    }

                    bunifuDropdown5.selectedIndex = yearNum;
                    bunifuDropdown4.selectedIndex = semNum;
                }
                con.Close();

            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(bunifuMaterialTextbox3.Text);
            string Name = bunifuMaterialTextbox1.Text;
            string ResittingModule = bunifuMaterialTextbox1.Text;

            string qry = "INSERT INTO Resitter Values (" + ID + ",'" + Name + "', '"+ResittingModule+"')";
            DatabaseConnection dbc = new DatabaseConnection();
            string feedback = dbc.DBConnection(qry);

            MessageBox.Show(feedback);


        }

        private void ResitRegis_Load(object sender, EventArgs e)
        {
            bunifuMaterialTextbox3.Select();
            this.ActiveControl = bunifuMaterialTextbox3;
            bunifuMaterialTextbox1.Focus();
        }
    }
}
