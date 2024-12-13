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
    public partial class Tests : Form
        
    {
        Functions Con;
        public Tests()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTest();

        }
        private void ShowTest()
        {
            string query = "SELECT * FROM TestTbl";
            TestsList.DataSource = Con.GetData(query);
        }

        private void Clear()
        {
            TNameTb.Text = "";
            TCostTb.Text = "";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (TNameTb.Text == "" || TCostTb.Text == "" )
            {
                MessageBox.Show("Missing Details!");
            }
            else
            {
                string TestName = TNameTb.Text;
                string TestCost = TCostTb.Text;
                string Query = "insert into TestTbl (TestName, TestCost) values('{0}','{1}')";
                Query = string.Format(Query, TestName, TestCost);
                Con.SetData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test Added Successfully");
            }
        }
        int key = 0;
        private void TestsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TNameTb.Text = TestsList.SelectedRows[0].Cells[1].Value.ToString();
            TCostTb.Text = TestsList.SelectedRows[0].Cells[2].Value.ToString();
            if (TNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                string selectedCellValue = TestsList.SelectedRows[0].Cells[0].Value.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (TNameTb.Text == "" || TCostTb.Text == "" )
            {
                MessageBox.Show("Missing Details!");
            }
            else
            {
                string TestName = TNameTb.Text;
                string TestCost = TCostTb.Text;

                string Query = "UPDATE TestTbl SET TestName='{0}', TestCost='{1}";
                Query = string.Format(Query, TestName, TestCost);
                Con.SetData(Query);
                MessageBox.Show("Patient Updated Successfully");
                ShowTest();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select a patient");

            }
            else
            {

                string Query = "Delete from TestTbl where TestCode = {0}"; ;
                Query = string.Format(Query, key);
                Con.SetData(Query);
                Clear();
                ShowTest();
                MessageBox.Show("Test Deleted Succesfully");

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Patient Obj = new Patient();
            Obj.Show();
            this.Hide();

        }
    }
    }

