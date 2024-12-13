using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HealthCareMiniProject
{
    public partial class Patient : Form
    {
        Functions Con;
        public Patient()
        {
            InitializeComponent();
            Con = new Functions(); // Initialize Con
            ShowPatients();

        }
        private void Clear()
        {
            PatNameTb.Text = "";
            PatPhoneTb.Text = "";
            PatAddTb.Text = "";
            GenCb.SelectedIndex = -1;
            DOBTb.Value = DateTime.Now;
        }
        private void ShowPatients()
        {
            string Query = "SELECT * FROM PatientTbl";
            PatientsLists.DataSource = Con.GetData(Query);
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PatNameTb.Text == "" || PatPhoneTb.Text == "" || PatAddTb.Text == "" || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Details!");
            }
            else
            {
                string Patient = PatNameTb.Text;
                string Gender = GenCb.SelectedItem.ToString();
                string BDate = DOBTb.Value.Date.ToString("yyyy-MM-dd"); // Format the date properly
                string Phone = PatPhoneTb.Text;
                string Address = PatAddTb.Text;
                string Query = "insert into PatientTbl (PatName, PatGen , PatDob, PatPhone, PatAdd) values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, Patient, Gender, BDate, Phone, Address);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Added Successfully");
            }
        }

        int key = 0;

        private void PatientsLists_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatNameTb.Text = PatientsLists.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = PatientsLists.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = PatientsLists.SelectedRows[0].Cells[3].Value.ToString();
            PatPhoneTb.Text = PatientsLists.SelectedRows[0].Cells[4].Value.ToString();
            PatAddTb.Text = PatientsLists.SelectedRows[0].Cells[5].Value.ToString();
            if (PatNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                string selectedCellValue = PatientsLists.SelectedRows[0].Cells[0].Value.ToString();
                if (!string.IsNullOrEmpty(selectedCellValue))
                {
                    try
                    {
                        key = Convert.ToInt32(selectedCellValue);
                        // Further processing using 'key' variable
                    }
                    catch (FormatException)
                    {
                        // Handle the format exception, e.g., display an error message
                        MessageBox.Show("Selected value is not a valid integer.");
                    }
                }
                else
                {
                    // Handle the case where the selected cell value is null or empty
                    MessageBox.Show("No value selected.");
                }


            }

        }






        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (PatNameTb.Text == "" || PatPhoneTb.Text == "" || PatAddTb.Text == "" || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Details!");
            }
            else
            {
                string Patient = PatNameTb.Text;
                string gender = GenCb.SelectedItem.ToString();
                string BDate = DOBTb.Value.Date.ToString("yyyy-MM-dd"); // Format the date properly
                string Phone = PatPhoneTb.Text;
                string Address = PatAddTb.Text;
                string Query = "UPDATE PatientTbl SET PatName='{0}', PatGen='{1}', PatDob='{2}', PatPhone='{3}', PatAdd='{4}";
                Query = string.Format(Query, Patient, gender, BDate, Phone, Address);
                Con.SetData(Query);
                MessageBox.Show("Patient Updated Successfully");
                ShowPatients();
            }

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select a patient");

            }
            else
            {

                string Query = "Delete from PatientTbl where Patcode = {0}"; ;
                Query = string.Format(Query, key);
                Con.SetData(Query);
                Clear();
                ShowPatients();
                MessageBox.Show("patient Deleted Succesfully");

            }
        }
            private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Patient Obj = new Patient();
            Obj.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Tests Obj = new Tests();
            Obj.Show();
            this.Hide();


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PatNameTb_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}

