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
    public partial class Lectures01 : Form
    {
        public Lectures01()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
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

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            ChooseForm cf = new ChooseForm();
            cf.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            LectureReg LecR = new LectureReg();
            LecR.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            LecViewDetal LecV = new LecViewDetal();
            LecV.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            LecRemv LecR = new LecRemv();
            LecR.Show();
            this.Hide();
        }

        private void Lectures01_Load(object sender, EventArgs e)
        {

        }
    }
}
