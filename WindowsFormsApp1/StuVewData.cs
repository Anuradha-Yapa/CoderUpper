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
    public partial class StuVewData : Form
    {
        public StuVewData()
        {
            InitializeComponent();
        }

        private void label22_Click(object sender, EventArgs e)
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Students01 st = new Students01();
            st.Show();
            this.Hide();
        }

        private void StuVewData_Load(object sender, EventArgs e)
        {
            DatabaseConnection dbc = new DatabaseConnection();

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

        /*private void label22_Click(object sender, EventArgs e)
        {
            
        } */


    }

