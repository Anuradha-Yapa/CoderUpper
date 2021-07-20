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
    public partial class StuRemv : Form
    {
        public StuRemv()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            Students01 st = new Students01();
            st.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(bunifuMetroTextbox1.Text);
            String del = "DELETE FROM Student where ID =" + ID + "";

            DatabaseConnection dbc = new DatabaseConnection();
            string feedback = dbc.DBConnection(del);
            MessageBox.Show(feedback);

            bunifuMetroTextbox1.Text = "";
        }

        private void StuRemv_Load(object sender, EventArgs e)
        {

            bunifuMetroTextbox1.Select();
            this.ActiveControl = bunifuMetroTextbox1;
            bunifuMetroTextbox1.Focus();
        }

        private void bunifuMetroTextbox8_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
