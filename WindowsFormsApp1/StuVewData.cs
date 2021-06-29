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
    public partial class StuVewData : Form
    {
        public StuVewData()
        {
            InitializeComponent();
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

        private void StuVewData_Load(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
