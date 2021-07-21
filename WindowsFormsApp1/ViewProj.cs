﻿using System;
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
    public partial class ViewProj : Form
    {
        DatabaseConnection dbc = new DatabaseConnection();
        public ViewProj()
        {
            InitializeComponent();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Project01 pro1 = new Project01();
            pro1.Show();
            this.Hide();

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

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewProj_Load(object sender, EventArgs e)
        {
            string con = dbc.ConString();
            string qry = "SELECT * FROM ResearchProjects";



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
    }
}
