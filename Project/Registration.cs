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
    public partial class Registration : MetroFramework .Forms .MetroForm
    
    {
        string x;
        public Registration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetValues();
        }
        void SetValues()
        {
            csProperties.Name = txtusername.Text;
            csProperties.Date = txtpass.Text;
            csProperties.ID = 2;
            csDBOperator obj = new csDBOperator();
            x = obj.mdDataFEED1();
            MessageBox.Show(x);
        }
      
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
