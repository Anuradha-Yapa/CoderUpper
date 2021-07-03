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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\WindowsFormsApp1\DatabaseCP.mdf;Integrated Security=True");
        public StudenReg()
        {
            InitializeComponent();
        }
        public void ID()
        {
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
                    ID = ("S1001");
                }
                else
                {
                    ID = ("S1001");
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

            TextBox(false);
            DropDown(true);

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\WindowsFormsApp1\DatabaseCP.mdf;Integrated Security=True";
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
            if (MessageBox.Show("Are You Sure You Want To Exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            string ID = bunifuMaterialTextbox12.Text;
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
            string OLMath = bunifuMetroTextbox2.Text;
            string OLEnglish = bunifuMetroTextbox1.Text;
            string ALEnglish = bunifuMetroTextbox3.Text;
            string ALIT = bunifuMetroTextbox4.Text;
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
            DBConnection dbc = new DBConnection();
            string feedback = dbc.DBCon(qry);

            MessageBox.Show(feedback);


        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
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
            string OLMath = bunifuMetroTextbox2.Text;
            string OLEnglish = bunifuMetroTextbox1.Text;
            string ALEnglish = bunifuMetroTextbox3.Text;
            string ALIT = bunifuMetroTextbox4.Text;
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

            string qry = "UPDATE Student SET Name = '" + Name + "', NIC = '" + NIC + "', DOBDate = '" + DOBDate + "', DOBMonth = '" + DOBMonth + "', DOBYear = '" + DOBYear + "', MobileNumber = " + MobileNumber + ", EmailAddress = '" + EmailAddress + "', Address = '" + Address + "', OLMath = '" + OLMath + "', OLEnglish = '" + OLEnglish + "', ALEnglsih = '" + ALEnglish + "', ALIT = '" + ALIT + "', Degree = '" + Degree + "', Year = '" + Year + "', Semester = '" + Semester + "' WHERE ID = " + ID + " ";
            DBConnection dbc = new DBConnection();
            string feedback = dbc.DBCon(qry);

            MessageBox.Show(feedback);

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\WindowsFormsApp1\DatabaseCP.mdf;Integrated Security=True");
            con.Open();

            if (bunifuMaterialTextbox12.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Name, NIC, DOBDate, DOBMonth, DOBYear, MobileNumber, EmailAddress, Address, OLMath, OLEnglish, ALEnglish, ALIT, Degree, Year, Semester where ID = @ID", con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(bunifuMaterialTextbox12.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    bunifuMaterialTextbox1.Text = da.GetValue(1).ToString();
                    bunifuMaterialTextbox10.Text = da.GetValue(2).ToString();

                    bunifuMaterialTextbox2.Text = da.GetValue(3).ToString();
                    bunifuMaterialTextbox7.Text = da.GetValue(4).ToString();
                    bunifuMaterialTextbox8.Text = da.GetValue(5).ToString();
                    bunifuMaterialTextbox9.Text = da.GetValue(13).ToString();
                    bunifuMaterialTextbox13.Text = da.GetValue(14).ToString();
                    bunifuMaterialTextbox14.Text = da.GetValue(9).ToString();
                    bunifuMaterialTextbox15.Text = da.GetValue(10).ToString();
                    bunifuMaterialTextbox16.Text = da.GetValue(11).ToString();
                    bunifuMaterialTextbox17.Text = da.GetValue(12).ToString();

                    bunifuMaterialTextbox4.Text = da.GetValue(6).ToString();
                    bunifuMaterialTextbox3.Text = da.GetValue(7).ToString();
                    bunifuMaterialTextbox5.Text = da.GetValue(8).ToString();
                    //bunifuMetroTextbox2.Text = da.GetValue(9).ToString();
                    //bunifuMetroTextbox1.Text = da.GetValue(10).ToString();
                    //bunifuMetroTextbox3.Text = da.GetValue(11).ToString();
                    //bunifuMetroTextbox4.Text = da.GetValue(12).ToString();
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

                    bunifuDropdown3.selectedIndex = yearNum;
                    bunifuDropdown1.selectedIndex = semNum;
                }
                con.Close();
            }

            DropDown(false);
            TextBox(true);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox12.Text = "";
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox4.Text = "";
            bunifuMaterialTextbox3.Text = "";
            bunifuMaterialTextbox10.Text = "";
            bunifuMaterialTextbox5.Text = "";
            bunifuMaterialTextbox6.Text = "";
            bunifuMaterialTextbox11.Text = "";

            TextBox(false);
            DropDown(true);

        }

        void DropDown(bool show)
        {
            bunifuDropdown1.Visible = show;
            bunifuDropdown2.Visible = show;
            bunifuDropdown3.Visible = show;
            bunifuDropdown5.Visible = show;
            bunifuDropdown4.Visible = show;
            bunifuMetroTextbox2.Visible = show;
            bunifuMetroTextbox1.Visible = show;
            bunifuMetroTextbox3.Visible = show;
            bunifuMetroTextbox4.Visible = show;
        }

        void TextBox(bool show)
        {
            bunifuMaterialTextbox2.Visible = show;
            bunifuMaterialTextbox7.Visible = show;
            bunifuMaterialTextbox8.Visible = show;
            bunifuMaterialTextbox9.Visible = show;
            bunifuMaterialTextbox13.Visible = show;
            bunifuMaterialTextbox14.Visible = show;
            bunifuMaterialTextbox15.Visible = show;
            bunifuMaterialTextbox16.Visible = show;
            bunifuMaterialTextbox17.Visible = show;
        }
    }
}
