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
    public partial class PaymentCof : Form
    {
        public PaymentCof()
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
            Payment01 pmnt = new Payment01();
            pmnt.Show();
            this.Hide();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            TextBox(false);
            DropDown(true);
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\WindowsFormsApp1\DatabaseCP.mdf;Integrated Security=True");
            con.Open();

            if (bunifuMaterialTextbox3.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Name, EmailAddress, Degree, Year, Semester from Student where ID = @ID", con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(bunifuMaterialTextbox3.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    bunifuMaterialTextbox4.Text = da.GetValue(1).ToString();
                    bunifuMaterialTextbox1.Text = da.GetValue(2).ToString();
                    bunifuMaterialTextbox2.Text = da.GetValue(3).ToString();


                    string years = da.GetValue(4).ToString();
                    string sem = da.GetValue(5).ToString();
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
            string StudentName = bunifuMaterialTextbox4.Text;
            string ResittingModule = bunifuMaterialTextbox5.Text;
            string InvoiceNumber = bunifuMaterialTextbox6.Text;

            string qry = "INSERT INTO Payments Values (" + ID + ",'" + StudentName + "','" + ResittingModule + "','" + InvoiceNumber + "')";
            DatabaseConnection dbc = new DatabaseConnection();
            string feedback = dbc.DBConnection(qry);

            MessageBox.Show(feedback);

            bunifuMaterialTextbox3.Text = "";
            bunifuMaterialTextbox4.Text = "";
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox2.Text = "";
            bunifuMaterialTextbox5.Text = "";
            bunifuMaterialTextbox3.Text = "";
            bunifuMaterialTextbox6.Text = "";
            DropDown(false);
            TextBox(true);
        }

        private void PaymentCof_Load(object sender, EventArgs e)
        {
            bunifuMaterialTextbox3.Select();
            this.ActiveControl = bunifuMaterialTextbox3;
            bunifuMaterialTextbox1.Focus();

            DropDown(true);
            TextBox(false);

        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {

        }

        public void DropDown(bool show)
        {
            bunifuDropdown5.Visible = show;
            bunifuDropdown4.Visible = show;
        }

        public void TextBox(bool show)
        {
            bunifuMaterialTextbox7.Visible = show;
            bunifuMaterialTextbox8.Visible = show;
        }

        private void bunifuMaterialTextbox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
