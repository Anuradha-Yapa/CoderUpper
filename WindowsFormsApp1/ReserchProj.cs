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
    public partial class ReserchProj : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\WindowsFormsApp1\DatabaseCP.mdf;Integrated Security=True");
        public ReserchProj()
        {
            InitializeComponent();
        }

        public void ID()
        {
            try
            {
                string ID;
                string query = "select ProjectID from ResearchProjects order by ProjectID Desc";
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

                bunifuMaterialTextbox1.Text = ID; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want To Exit?", "CONFIRM EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Activate();
            }
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
            DatabaseConnection dbc = new DatabaseConnection();
            string feedback = dbc.DBConnection(qry);

            MessageBox.Show(feedback);

        }

        private void ReserchProj_Load(object sender, EventArgs e)
        {
            ID();

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\WindowsFormsApp1\DatabaseCP.mdf;Integrated Security=True";
            string qry = "SELECT * FROM ResearchProject";



            try
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "ResearchProjects");
                dataGridView1.DataSource = ds.Tables["ResearchProjects"];
            }



            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\WindowsFormsApp1\DatabaseCP.mdf;Integrated Security=True");
            con.Open();

            if (bunifuMaterialTextbox1.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT ProjectID, ProjectName, Area, Description, Duration, Status, Supervisors, StudentName, StudentID where ProjectID = @ProjectID", con);

                cmd.Parameters.AddWithValue("@ProjectID", int.Parse(bunifuMaterialTextbox1.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    bunifuMaterialTextbox2.Text = da.GetValue(1).ToString();
                    bunifuMaterialTextbox4.Text = da.GetValue(2).ToString();

                    bunifuMaterialTextbox7.Text = da.GetValue(3).ToString();
                    bunifuMaterialTextbox9.Text = da.GetValue(4).ToString();

                    string stat = da.GetValue(5).ToString();

                    int statNum = 0;
                    if (stat == "Approved")
                    {
                        statNum = 0;
                    }
                    else if (stat == "Denied")
                    {
                        statNum = 1;
                    }
                    else
                    {
                        statNum = 3;
                    }

                    bunifuMaterialTextbox10.Text = da.GetValue(6).ToString();
                    bunifuMaterialTextbox6.Text = da.GetValue(7).ToString();
                    bunifuMaterialTextbox8.Text = da.GetValue(8).ToString();

                }
                con.Close();

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox2.Text = "";
            bunifuMaterialTextbox7.Text = "";
            bunifuMaterialTextbox5.Text = "";
            bunifuMaterialTextbox9.Text = "";
            bunifuMaterialTextbox10.Text = "";
            bunifuMaterialTextbox3.Text = "";
            bunifuMaterialTextbox6.Text = "";
            bunifuMaterialTextbox8.Text = "";
            bunifuMaterialTextbox4.Text = "";
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            int ProjectID = int.Parse(bunifuMaterialTextbox1.Text);
            string ProjectName = bunifuMaterialTextbox2.Text;
            string Area = bunifuMaterialTextbox4.Text;
            string Description = bunifuMaterialTextbox7.Text;
            string Duration = bunifuMaterialTextbox9.Text;

            string Status = "";
            if (bunifuDropdown3.selectedIndex == 0)
            {
                Status = "Approved";
            }
            else if (bunifuDropdown3.selectedIndex == 1)
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

            string qry = "UPDATE ResearchProjects SET ProjectName='" + ProjectName + "',Area='" + Area + "',Description='" + Description + "',Duration='" + Duration + "',Status='" + Status + "',Supervisors='" + Supervisors + "', StudentName='" + StudentName + "',StudentID= " + StudentID + " WHERE ProjectID = " + ProjectID + "  ";
            DatabaseConnection dbc = new DatabaseConnection();
            string feedback = dbc.DBConnection(qry);

            MessageBox.Show(feedback);
        }
    }
}
