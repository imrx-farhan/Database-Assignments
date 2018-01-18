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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Button_login_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            

           
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string userName = textBox_user_name.Text;
            string password = textBox_password.Text;
            //Control.if empty or remove special charctaee

            string query = string.Format("select * from UMS_tbl_Users where Users='{0}' and Passwords='{1}'", userName, password);

            DataTable dt = new DataTable();
            using (DBhelper1 dbhelper = new DBhelper1())
            {
                dt = dbhelper.GetRecords(query);
            }
            if (dt.Rows.Count > 0)
            {
                Main frm = new Main();
                frm.ShowDialog();
            }
        }
    }
}


