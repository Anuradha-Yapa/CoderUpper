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

    public partial class StudenReg : Form
    {

        DatabaseConnection dbc = new DatabaseConnection();

        public StudenReg()
        {
            InitializeComponent();
        }

        public void ID()
        {
            SqlConnection con = new SqlConnection(dbc.ConString());

            try
            {
                string ID;
                string query = "select ID from Student order by ID Desc";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString()) + 1;
                    ID = id.ToString("00000");
                }
                else if (Convert.IsDBNull(dr))
                {
                    ID = ("00001");
                }
                else
                {
                    ID = ("00001");
                }
                con.Close();

                bunifuMaterialTextbox12.Text = ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ID();

            bunifuMaterialTextbox1.Select();
            this.ActiveControl = bunifuMaterialTextbox1;
            bunifuMaterialTextbox1.Focus();

            DropDownMDY(true);
            DropDownAQ(true);
            DropDownSY(true);
            TextBoxMDY(false);
            TextBoxAQ(false);
            TextBoxSY(false);
            LongTextBox(false);

            string con = dbc.ConString();
            string qry = "SELECT * FROM Student";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Student");
                dataGridView1.DataSource = ds.Tables["Student"]; 
            }

            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
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
            if (MessageBox.Show("Are You Sure You Want To Exit?", "CONFIRM EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Activate();
            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string con = dbc.ConString();

            int ID = int.Parse(bunifuMaterialTextbox12.Text);
            string Name = bunifuMaterialTextbox1.Text;
            string NIC = bunifuMaterialTextbox10.Text;
            int MobileNumber = int.Parse(bunifuMaterialTextbox4.Text);
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

            string EmailAddress = bunifuMaterialTextbox3.Text;
            string Address = bunifuMaterialTextbox5.Text;
            string OLMath = bunifuMetroTextbox5.Text;
            string OLEnglish = bunifuMetroTextbox6.Text;
            string ALEnglish = bunifuMetroTextbox3.Text;
            string ALIT = bunifuMetroTextbox7.Text;
            string Degree = bunifuMaterialTextbox11.Text;
            string Year = "";
            if (bunifuDropdown5.selectedIndex == 0)
            {
                Year = "Year 1";
            }
            else if (bunifuDropdown5.selectedIndex == 1)
            {
                Year = "Year 2";
            }
            else if (bunifuDropdown5.selectedIndex == 2)
            {
                Year = "Year 3";
            }
            else
            {
                Year = "Year 4";
            }

            string Semester = "";
            if (bunifuDropdown4.selectedIndex == 0)
            {
                Semester = "Semester 01";
            }

            else if (bunifuDropdown4.selectedIndex == 1)
            {
                Semester = "Semester 02";
            }

            else
            {
                Semester = "Semester 03";
            }

            string qry = "INSERT INTO Student Values ('" + ID + "','" + Name + "','" + NIC + "','" + DOBDate + "','" + DOBMonth + "','" + DOBYear + "'," + MobileNumber + ",'" + EmailAddress + "','" + Address + "','" + OLMath + "','" + OLEnglish + "','" + ALEnglish + "','" + ALIT + "','" + Degree + "','" + Year + "','" + Semester + "')";
            
            string feedback = dbc.DBConnection(qry);
            MessageBox.Show(feedback);

            string qry2 = "select * from Student";
            SqlDataAdapter ad = new SqlDataAdapter(qry2, con);
            DataSet set = new DataSet();
            ad.Fill(set, "Student");
            dataGridView1.DataSource = set.Tables["Student"];

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            string con = dbc.ConString();

            int ID = int.Parse(bunifuMaterialTextbox12.Text);
            string Name = bunifuMaterialTextbox1.Text;
            string NIC = bunifuMaterialTextbox10.Text;
            string MobileNumber = bunifuMaterialTextbox4.Text;

            string EmailAddress = bunifuMaterialTextbox3.Text;
            string Address = bunifuMaterialTextbox5.Text;
            string OLMath = bunifuMetroTextbox5.Text;
            string OLEnglish = bunifuMetroTextbox6.Text;
            string ALEnglish = bunifuMetroTextbox3.Text;
            string ALIT = bunifuMetroTextbox7.Text;
            string Degree = bunifuMaterialTextbox11.Text;
            string Year = "";
            if (bunifuDropdown5.selectedIndex == 0)
            {
                Year = "Year 1";
            }
            else if (bunifuDropdown5.selectedIndex == 1)
            {
                Year = "Year 2";
            }
            else if (bunifuDropdown5.selectedIndex == 2)
            {
                Year = "Year 3";
            }
            else
            {
                Year = "Year 4";
            }

            string Semester = "";
            if (bunifuDropdown4.selectedIndex == 0)
            {
                Semester = "Semester 01";
            }

            else if (bunifuDropdown4.selectedIndex == 1)
            {
                Semester = "Semester 02";
            }

            else
            {
                Semester = "Semester 03";
            }

            string qry = "UPDATE Student SET Name = '" + Name + "', NIC = '" + NIC + "', MobileNumber = '" + MobileNumber + "', EmailAddress = '" + EmailAddress + "', Address = '" + Address + "', OLMath = '" + OLMath + "', OLEnglish = '" + OLEnglish + "', ALEnglish = '" + ALEnglish + "', ALIT = '" + ALIT + "', Degree = '" + Degree + "', Year = '" + Year + "', Semester = '" + Semester + "' WHERE ID = " + ID + " ";
            
            string feedback = dbc.DBConnection(qry);
            MessageBox.Show(feedback);

            string qry2 = "select * from Student";
            SqlDataAdapter ad = new SqlDataAdapter(qry2, con);
            DataSet set = new DataSet();
            ad.Fill(set, "Student");
            dataGridView1.DataSource = set.Tables["Student"];

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

            TextBoxMDY(true);
            DropDownMDY(false);
            DropDownAQ(true);
            TextBoxAQ(false);
            DropDownSY(true);
            TextBoxSY(false);
            LongTextBox(false);

            SqlConnection con = new SqlConnection(dbc.ConString());
            con.Open();

            if (bunifuMaterialTextbox12.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Name, NIC, DOBDate, DOBMonth, DOBYear, MobileNumber, EmailAddress, Address, OLMath, OLEnglish, ALEnglish, ALIT, Degree, Year, Semester from Student where ID = @ID", con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(bunifuMaterialTextbox12.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                   
                    bunifuMaterialTextbox1.Text = da.GetValue(1).ToString();
                    bunifuMaterialTextbox10.Text = da.GetValue(2).ToString();
                    bunifuMaterialTextbox2.Text = da.GetValue(3).ToString();
                    bunifuMaterialTextbox7.Text = da.GetValue(4).ToString();
                    bunifuMaterialTextbox8.Text = da.GetValue(5).ToString();
                    bunifuMaterialTextbox4.Text = da.GetValue(6).ToString();
                    bunifuMaterialTextbox3.Text = da.GetValue(7).ToString();
                    bunifuMaterialTextbox5.Text = da.GetValue(8).ToString();
                    bunifuMetroTextbox5.Text = da.GetValue(9).ToString();
                    bunifuMetroTextbox6.Text = da.GetValue(10).ToString();
                    bunifuMetroTextbox3.Text = da.GetValue(11).ToString();
                    bunifuMetroTextbox7.Text = da.GetValue(12).ToString();
                    bunifuMaterialTextbox11.Text = da.GetValue(13).ToString();

                    string years = da.GetValue(14).ToString();
                    string sem = da.GetValue(15).ToString();
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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            TextBoxMDY(false);
            DropDownMDY(false);
            TextBoxAQ(true);
            DropDownAQ(false);
            TextBoxSY(true);
            DropDownSY(false);
            LongTextBox(true);

            bunifuMaterialTextbox12.Text = "";
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox4.Text = "";
            bunifuMaterialTextbox3.Text = "";
            bunifuMaterialTextbox10.Text = "";
            bunifuMaterialTextbox5.Text = "";
            bunifuMaterialTextbox6.Text = "";
            bunifuMaterialTextbox11.Text = "";

        }

        void DropDownMDY(bool show)
        {
            bunifuDropdown1.Visible = show;
            bunifuDropdown2.Visible = show;
            bunifuDropdown3.Visible = show;
        }

        void DropDownAQ(bool show)
        {
            bunifuMetroTextbox2.Visible = show;
            bunifuMetroTextbox1.Visible = show;
            bunifuMetroTextbox3.Visible = show;
            bunifuMetroTextbox4.Visible = show;
        }

        void DropDownSY(bool show)
        {
            bunifuDropdown5.Visible = show;
            bunifuDropdown4.Visible = show;
        }

        void TextBoxMDY(bool show)
        {
            bunifuMaterialTextbox2.Visible = show;
            bunifuMaterialTextbox7.Visible = show;
            bunifuMaterialTextbox8.Visible = show;
        }

        void TextBoxAQ(bool show)
        {
            bunifuMetroTextbox8.Visible = show;
            bunifuMetroTextbox9.Visible = show;
            bunifuMetroTextbox10.Visible = show;
            bunifuMetroTextbox11.Visible = show;
        }


        void TextBoxSY(bool show)
        {
            bunifuMaterialTextbox9.Visible = show;
            bunifuMaterialTextbox13.Visible = show;
        }

        void LongTextBox(bool show)
        {
            bunifuMaterialTextbox14.Visible = show;
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMaterialTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMaterialTextbox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMaterialTextbox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMaterialTextbox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMaterialTextbox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMaterialTextbox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMetroTextbox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMetroTextbox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMetroTextbox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuMetroTextbox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
