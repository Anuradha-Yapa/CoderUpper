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
    public partial class AssigningGrade : Form
    {
        public AssigningGrade()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Exam01 Ex1 = new Exam01();
            Ex1.Show();
            this.Hide();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\WindowsFormsApp1\DatabaseCP.mdf;Integrated Security=True");
            con.Open();

            if (bunifuMaterialTextbox3.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Name, Degree, Year, Semester from Student where ID = @ID", con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(bunifuMaterialTextbox3.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    bunifuMaterialTextbox1.Text = da.GetValue(1).ToString();
                    bunifuMaterialTextbox2.Text = da.GetValue(2).ToString();

                    string YEAR = da.GetValue(3).ToString();
                    string SEM = da.GetValue(4).ToString();

                    bunifuDropdown3.Text = YEAR;
                    bunifuDropdown1.Text = SEM;
                }
                con.Close();

            }
        }
    }
}
