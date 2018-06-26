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
    public partial class BuyStock : MetroFramework.Forms.MetroForm
    {
        decimal bal, curent,val,tot,temp;
        double bal1, vall, grandbal;
        int stoks;
        string x;

        private void button2_Click(object sender, EventArgs e)
        {
            csDBOperator obj = new csDBOperator();
            string msg = obj.mdDataFEED2();
            MessageBox.Show(msg);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void LoadData()
        {
            csDBOperator obj = new csDBOperator();
            dataGridView1.DataSource = obj.mViewBUY(out x).DefaultView;

        }
        public BuyStock(string curentval,decimal balance)
        {
            InitializeComponent();
            LoadData();
            curent = Convert.ToDecimal(curentval);
            bal = Convert.ToDecimal(balance);
            lblbalance.Text = balance.ToString();
            lblname.Text = csProperties.UserName;
            lblbcurrent.Text = curentval.ToString();
            Dvalues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              Dcal(); setValue();
        }
        void setValue()
        {
            csProperties.Number = Convert.ToInt16(textBox1.Text);
            csProperties.Balance = Convert.ToDecimal(lblbalance.Text);
            csProperties.Price = Convert.ToDecimal(lblbcurrent.Text);
            csProperties.ID1 = 1;
            csProperties.ID = 1;
               
        }

        void Dvalues()
        {
           val = bal / curent;
           label4.Text = val.ToString();
        }
        void Dcal()
        {
            stoks = Convert.ToInt16(textBox1.Text);
            temp = stoks * curent;
            label7.Text = temp.ToString();
             bal1 = Convert.ToDouble(lblbalance.Text);
             vall = Convert.ToDouble(label7.Text);
             grandbal = bal1 - vall;
            lblbalance.Text = grandbal.ToString();

        }
        private void BuyStock_Load(object sender, EventArgs e)
        {

        }
    }
}
