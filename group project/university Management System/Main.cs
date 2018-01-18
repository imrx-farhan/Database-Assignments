using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace university_Management_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadProductGridView();
        }

        void LoadProductGridView()
        {
            dataGridView1.Rows.Clear();
            string query = "select Student_ID,Student_Name,Gender,Student_Address from UMS_tbl_Students ";
            DataTable dt = new DataTable();

            using (DBhelper1 dbHelper = new DBhelper1())
            {
                dt = dbHelper.GetRecords(query);
            }

            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2],row[3]);
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string student_name = textBox_student_name.Text;
            string student_gender = textBox_gender.Text;
            string student_address = textBox_student_address.Text;

            string query = "insert into UMS_tbl_Students(Student_Name,Gender,Student_Address)VALUES('" + student_name + "','" + student_gender + "','" + student_address + "')";


            using (DBhelper1 dbHelper = new DBhelper1())
            {
                dbHelper.ExecuteQuery(query);
            }
            LoadProductGridView();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
