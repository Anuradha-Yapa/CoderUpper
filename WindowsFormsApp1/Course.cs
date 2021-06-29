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
    public partial class Course : Form
    {
        public Course()
        {
            InitializeComponent();
        }

        private void Course_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Course01 curs1 = new Course01();
            curs1.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
