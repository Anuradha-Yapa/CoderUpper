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
    public partial class ViewPay : Form
    {
        public ViewPay()
        {
            InitializeComponent();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Payment01 Pay1 = new Payment01();
            Pay1.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Exit the Program?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                this.Activate();
            }
        }

        private void ViewPay_Load(object sender, EventArgs e)
        {
            
        }
    }
}
