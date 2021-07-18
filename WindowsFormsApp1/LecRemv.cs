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
    public partial class LecRemv : Form
    {
        public LecRemv()
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Lectures01 Lec1 = new Lectures01();
            Lec1.Show();
            this.Hide();

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            int lectureID = int.Parse(bunifuMetroTextbox8.Text);

            String del = "DELETE FROM  Lecturer where ID =" + lectureID + "";

            DatabaseConnection dbc = new DatabaseConnection();
            string feedback = dbc.DBConnection(del);

            MessageBox.Show(feedback);
            bunifuMetroTextbox8.Text = "";
        }

        private void LecRemv_Load(object sender, EventArgs e)
        {

            bunifuMetroTextbox8.Select();
            this.ActiveControl = bunifuMetroTextbox8;
            bunifuMetroTextbox8.Focus();
        }
    }
}
