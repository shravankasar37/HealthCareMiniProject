using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareMiniProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || passwordTb.Text == "")
            {
                MessageBox.Show("Enter Username And Password ");

            }
            else
            {
                if (UnameTb.Text == "shravan" && passwordTb.Text == "shravan@123")
                {
                    Patient Obj = new Patient();
                    Obj.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Wrong Username or password ");
                    Unamelb.Text = "";
                    passwordTb.Text = "";
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            passwordTb.Text = "";

        }
    }
}
