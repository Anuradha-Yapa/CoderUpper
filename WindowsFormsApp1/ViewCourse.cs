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
    public partial class ViewCourse : Form
    {
        public ViewCourse()
        {
            InitializeComponent();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Course01 c1 = new Course01();
            c1.Show();
            this.Hide();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
