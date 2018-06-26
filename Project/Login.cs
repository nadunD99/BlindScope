using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace Project
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        string ex, name;
        public Login()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setValues();
        }
        void setValues()
        {
            csProperties.Name = txtUsername.Text;
            csProperties.Pword = txtPw.Text;
            csProperties.UserName = txtUsername.Text;
            csDBOperator obj = new csDBOperator();
            int count = obj.mgetLogin(out ex, out name);
            if (count == 1)
            {
                MessageBox.Show("Welcome Mr:" + name);
                Form1 obj00 = new Form1(name);
                this.Hide();
                obj00.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Inccorect User name or password");
               
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration obj = new Registration();
            obj.Show();
        }
        
    }
}
